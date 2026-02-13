using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    // Movement-related
    private float _movementX;
    private float _movementY;
    public float speed = 5;
    
    private Inventory _playerInventory;
    private List<GameObject> _inVicinity = new List<GameObject>();
    
    public GameObject dialogueUI;
    void Start()
    {
        _playerInventory = InitializeInventory();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        
    }

    void OnMove(InputValue movementValue)
    {
        _movementX = movementValue.Get<Vector2>().x;
        _movementY = movementValue.Get<Vector2>().y;
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (_movementX, 0.0f, _movementY) * speed;
        _rigidbody.linearVelocity = movement;
    }

    void OnInteract(InputValue value)
    {
        if (value.isPressed && _inVicinity.Count > 0)
        {
            GameObject closest = FindClosest(_inVicinity, transform.position);
            
            IInteractable interactable = closest.GetComponent<IInteractable>();
            interactable.Interact();
        }
    }
    
    GameObject FindClosest(List<GameObject> list, Vector3 from)
    {
        GameObject closest = null;
        float minDistSq = float.MaxValue;

        foreach (var obj in list)
        {
            float d = (obj.transform.position - from).sqrMagnitude;
            if (d < minDistSq)
            {
                minDistSq = d;
                closest = obj;
            }
        }
        return closest;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Buy") || collision.gameObject.CompareTag("Sell") )
        {
            ShopItemDetails details = collision.gameObject.GetComponentInParent<ShopItemDetails>();

            
            if (collision.gameObject.CompareTag("Buy"))
            {
                if (_playerInventory.balance < details.price)
                {
                    Debug.Log("You're broke, bro!");
                }
                else
                {
                    bool inInventory = false;
                    foreach (Item i in _playerInventory.items)
                    {
                        if (i.type == details.itemType)
                        {
                            i.quantity++;
                            inInventory = true;
                            break;
                        }
                    }
                    if (!inInventory)
                    {
                        Item newItem = new Item();
                        newItem.type = details.itemType;
                        newItem.quantity = 1;
                        _playerInventory.items.Add(newItem);
                    }
                    
                    _playerInventory.balance -= details.price;
                    Debug.Log($"Successfully bought {details.itemType} for TK.{details.price}!");
                }
            }
            else
            {
                bool canSell = false;
                foreach (Item i in _playerInventory.items)
                {
                    if (i.type == details.itemType)
                    {
                        if (i.quantity > 0)
                        {
                            canSell = true;
                            i.quantity--;
                            _playerInventory.balance += details.price;
                            Debug.Log($"Successfully sold {details.itemType} for TK.{details.price}!");
                            
                        }
                        break;
                    }
                }
                if (!canSell)
                {
                    Debug.Log("You ain't got that shit, bro!");
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            GameObject npc = other.gameObject;
            GameObject npcNameTag = npc.transform.GetChild(0).gameObject;
            
            _inVicinity.Add(npc);
            npcNameTag.SetActive(true);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            GameObject npc = other.gameObject;
            GameObject npcNameTag = npc.transform.GetChild(0).gameObject;
            
            _inVicinity.Remove(npc);
            npcNameTag.SetActive(false);
        }
    }
    
    Inventory InitializeInventory()
    {
        string path = Application.persistentDataPath + "/inventory.json";
        Inventory inventory;
        if (!File.Exists(path))
        {
            inventory = new Inventory();
        }
        else
        {
            string json = File.ReadAllText(path);
            inventory = JsonUtility.FromJson<Inventory>(json);
        }
        return inventory;
    }

    void SaveInventory(Inventory inventory)
    {
        string json = JsonUtility.ToJson(inventory, true);
        File.WriteAllText(Application.persistentDataPath + "/inventory.json", json);
    }

    private void OnApplicationQuit()
    {
        SaveInventory(_playerInventory);
    }
}
