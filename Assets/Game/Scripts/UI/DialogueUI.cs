using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    public TMP_Text speakerName;
    public TMP_Text speakerRole;
    public TMP_Text dialogue;
    public List<string> dialogues;
    public int dialogueIndex;
    

    public void UpdateSpeakerName(string newSpeakerName)
    {
        speakerName.text = newSpeakerName;
    }
    public void UpdateSpeakerRole(string newSpeakerRole)
    {
        speakerRole.text = newSpeakerRole;
    }
    public void UpdateDialogue(List<string> newDialogues)
    {
        dialogues = newDialogues;
        dialogueIndex = 0;
        dialogue.text = dialogues[dialogueIndex];
    }

    public void NextDialogue()
    {
        dialogueIndex++;
        if (dialogueIndex >= dialogues.Count) {return;}
        dialogue.text = dialogues[dialogueIndex];
    }
}
