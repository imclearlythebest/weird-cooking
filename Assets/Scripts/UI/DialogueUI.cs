using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    public TMP_Text speakerName;
    public TMP_Text speakerRole;
    public TMP_Text dialogue;

    public void UpdateSpeakerName(string newSpeakerName)
    {
        speakerName.text = newSpeakerName;
    }
    public void UpdateSpeakerRole(string newSpeakerRole)
    {
        speakerRole.text = newSpeakerRole;
    }
    public void UpdateDialogue(string newDialogue)
    {
        dialogue.text = newDialogue;
    }
}
