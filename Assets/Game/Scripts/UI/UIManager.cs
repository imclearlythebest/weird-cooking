using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject dialogueUI;
    void Awake()
    {
        if (Instance == null) {Instance = this;}
        else {Destroy(gameObject);}    
    }
}
