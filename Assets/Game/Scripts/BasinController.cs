using UnityEngine;

public class BasinController : MonoBehaviour, IInteractable
{
   public GameObject waterRising;
   public GameObject waterFalling;
   
   public void Interact()
   {
      waterRising.SetActive(!waterRising.activeSelf);
      waterFalling.SetActive(!waterFalling.activeSelf);
   }
}
