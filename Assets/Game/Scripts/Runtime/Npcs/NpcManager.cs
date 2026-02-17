using System.Collections.Generic;
using UnityEngine;
public class NpcManager : MonoBehaviour
{
    public static NpcManager Instance;
    private Dictionary<int, NpcDefinition> _npcById; 
    
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
            NpcDefinition[] allNpcs = Resources.LoadAll<NpcDefinition>("Npcs");
            _npcById = new Dictionary<int, NpcDefinition>();
            foreach (NpcDefinition npc in allNpcs)
            {
                _npcById.Add(npc.id, npc);
            }
        }
    }

    public NpcDefinition GetNpcById(int id)
    {
        _npcById.TryGetValue(id, out var npc);
        return npc;
    }
}
