using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTo : MonoBehaviour, IInteractable
{
    public SceneAsset scene;
    public void Interact()
    {
        SceneManager.LoadScene(scene.name);
    }
}
