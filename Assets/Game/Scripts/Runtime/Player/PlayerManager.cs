using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    private readonly string _savePath = Application.persistentDataPath + "saves/player.json";
    public PlayerData data;
    private bool AwakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return true;
        }
        else
        {
            Destroy(gameObject);
            return false;
        }
    }
    private void Awake()
    {
        if (AwakeSingleton())
        {
            string json =  System.IO.File.ReadAllText(_savePath);
            data = JsonUtility.FromJson<PlayerData>(json) ?? new PlayerData();
        }
    }
    public void Save()
    {
        System.IO.File.WriteAllText(_savePath, JsonUtility.ToJson(data));
    }
}
