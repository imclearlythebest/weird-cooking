using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance;

    public GameObject panel;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Button button1;
    public Button button2;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        panel.SetActive(false);
    }

    // Show dialogue with text and optional button callbacks
    public void ShowDialogue(string npcName, string dialogue, string btn1Text = null, UnityEngine.Events.UnityAction btn1Action = null,
        string btn2Text = null, UnityEngine.Events.UnityAction btn2Action = null)
    {
        nameText.text = npcName;
        dialogueText.text = dialogue;

        panel.SetActive(true);

        // Button 1 setup
        if (btn1Text != null && btn1Action != null)
        {
            button1.gameObject.SetActive(true);
            button1.GetComponentInChildren<TMP_Text>().text = btn1Text;
            button1.onClick.RemoveAllListeners();
            button1.onClick.AddListener(btn1Action);
        }
        else
        {
            button1.gameObject.SetActive(false);
        }

        // Button 2 setup
        if (btn2Text != null && btn2Action != null)
        {
            button2.gameObject.SetActive(true);
            button2.GetComponentInChildren<TMP_Text>().text = btn2Text;
            button2.onClick.RemoveAllListeners();
            button2.onClick.AddListener(btn2Action);
        }
        else
        {
            button2.gameObject.SetActive(false);
        }
    }

    // Simple helper to hide dialogue
    public void HideDialogue()
    {
        panel.SetActive(false);
    }
}