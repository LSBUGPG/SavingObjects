using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public string ground;
    public Block [] blocks;

    public static LevelData LoadFromJSON(string json)
    {
        return JsonUtility.FromJson<LevelData>(json);
    }

    public string SaveToJSON()
    {
        bool pretty = true;
        return JsonUtility.ToJson(this, pretty);
    }
}
