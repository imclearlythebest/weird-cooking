using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    // Movement-related
    private float _movementX;
    private float _movementY;
    public float speed = 5;

    void Start()
    {
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Buy") || collision.gameObject.CompareTag("Sell") )
        {
            ShopItemDetails details = collision.gameObject.GetComponentInParent<ShopItemDetails>();
            float price = details.price;
            string itemName = details.itemName;
            
            if (collision.gameObject.CompareTag("Buy"))
            {
                Debug.Log("Bought " + itemName + " for " + price);
            }
            else
            {
                Debug.Log("Sold " + itemName + " for " + price);
            }
        }
    }
}
