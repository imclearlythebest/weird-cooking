using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTo : MonoBehaviour, IInteractable
{
    public SceneAsset Scene;
    public void Interact()
    {
        SceneManager.LoadScene(Scene.name);
    }
}
