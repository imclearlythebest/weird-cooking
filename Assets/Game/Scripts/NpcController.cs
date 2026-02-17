using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcController : MonoBehaviour, IInteractable
{
    private bool _isKnown;
    [SerializeField] private int npcId;
    private GameObject _dialogueUI;
    private DialogueUI _dialogueManager;
    private NpcDefinition _npcDefinition;
    
    private void Start()
    {
        _npcDefinition = NpcManager.Instance.GetNpcById(npcId);
        _dialogueUI = UIManager.Instance.dialogueUI;
        _dialogueManager = _dialogueUI.GetComponent<DialogueUI>();
        var npcName = _npcDefinition.npcName;
        transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = npcName;
    }

    public void Interact()
    {
        List<string> dialogue;
        _dialogueManager.UpdateSpeakerName(_npcDefinition.npcName);
        _dialogueManager.UpdateSpeakerRole(_npcDefinition.role);

        if (_isKnown)
        {
            dialogue = _npcDefinition.defaultDialogue;
        }
        else
        {
            _isKnown = true;
            dialogue = _npcDefinition.introDialogue;
        }
        
        _dialogueManager.UpdateDialogue(dialogue);
        _dialogueUI.SetActive(true);
    }
}
