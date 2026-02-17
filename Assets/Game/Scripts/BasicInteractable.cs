using UnityEngine;

public class BasicInteractable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interact");
    }
}
