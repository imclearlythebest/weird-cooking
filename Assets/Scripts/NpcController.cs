using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class NpcController : MonoBehaviour, IInteractable
{
    private bool _npcMet;
    public int npcId;
    private string _npcName;
    private string _npcRole;
    private List<string> _npcDefaultDialogue;
    private List<string> _npcIntroduction;
    private GameObject _dialogueUI;
    private DialogueUI _dialogueManager;
    private NpcDatabase _db;

    private void Start()
    {
        string path = "Assets/Database/NpcDatabase.json";
        string json = File.ReadAllText(path);
        _db = JsonUtility.FromJson<NpcDatabase>(json);
        _npcName = _db.npcs[npcId].npcName;
        _npcRole = _db.npcs[npcId].npcRole;
        _npcDefaultDialogue = _db.npcs[npcId].npcDefaultDialogue;
        _npcIntroduction = _db.npcs[npcId].npcIntroduction;
        _npcMet = _db.npcs[npcId].npcMet;
        _dialogueUI = UIManager.Instance.dialogueUI;
        _dialogueManager = _dialogueUI.GetComponent<DialogueUI>();
        transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = _npcName;
    }

    public void Interact()
    {
        List<string> dialogue;
        _dialogueManager.UpdateSpeakerName(_npcName);
        _dialogueManager.UpdateSpeakerRole(_npcRole);

        if (_npcMet)
        {
            dialogue = _npcDefaultDialogue;
        }
        else
        {
            _npcMet = true;
            _db.npcs[npcId].npcMet = true;
            dialogue = _npcIntroduction;
        }
        
        _dialogueManager.UpdateDialogue(dialogue);
        _dialogueUI.SetActive(true);
    }
    void SaveNpcs(NpcDatabase npcDatabase)
    {
        string json = JsonUtility.ToJson(npcDatabase, true);
        File.WriteAllText("Assets/Database/NpcDatabase.json", json);
    }

    private void OnApplicationQuit()
    {
        SaveNpcs(_db);
    }
}
