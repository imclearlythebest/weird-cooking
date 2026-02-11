using TMPro;
using UnityEngine;

public class NpcController : MonoBehaviour, IInteractable
{
    public string npcName;
    public string npcRole;
    public string npcDefaultDialogue;
    public string npcIntroduction;
    private bool _npcMet;
    
    private GameObject _dialogueUI;
    private DialogueUI _dialogueManager;

    private void Start()
    {
        _dialogueUI = UIManager.Instance.dialogueUI;
        _dialogueManager = _dialogueUI.GetComponent<DialogueUI>();
        transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = npcName;
    }

    public void Interact()
    {
        string dialogue;
        _dialogueManager.UpdateSpeakerName(npcName);
        _dialogueManager.UpdateSpeakerRole(npcRole);

        if (_npcMet)
        {
            dialogue = npcDefaultDialogue;
        }
        else
        {
            _npcMet = true;
            dialogue = npcIntroduction;
        }
        
        _dialogueManager.UpdateDialogue(dialogue);
        _dialogueUI.SetActive(true);
        
    }
}
