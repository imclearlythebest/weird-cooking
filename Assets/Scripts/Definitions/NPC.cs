using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NpcData
{
    public int npcID;
    public string npcName;
    public string npcRole;
    public List<string> npcDefaultDialogue;
    public List<string> npcIntroduction;
    public bool npcMet;
}

[System.Serializable]
public class NpcDatabase
{
    public List<NpcData> npcs;
}