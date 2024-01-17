using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Level : MonoBehaviour
{
    new public Camera camera;
    public Ground ground;
    public Transform blockPrefab;
    List<Transform> blocks = new List<Transform>();

    public void Clear()
    {
        ground.Clear();
        foreach (Transform block in blocks)
        {
            Destroy(block.gameObject);
        }
        blocks.Clear();
    }

    string Path()
    {
        return $"{Application.persistentDataPath}/Level.json";
    }

    string LoadJSON()
    {
        string json;
        using (StreamReader reader = new StreamReader(Path()))
        {
            json = reader.ReadToEnd();
            Debug.Log($"Loaded from {Path()}");
        }
        return json;
    }

    void LoadFromLevelData(LevelData levelData)
    {
        Clear();
        ground.SetMaterial(levelData.ground);
        foreach (Block block in levelData.blocks)
        {
            CreateNewBlock(block.position, block.orientation);
        }
    }

    public void Load()
    {
        string json = LoadJSON();
        LevelData levelData = LevelData.LoadFromJSON(json);
        LoadFromLevelData(levelData);
    }

    void SaveJSON(string json)
    {
        using (StreamWriter writer = new StreamWriter(Path()))
        {
            writer.Write(json);
            Debug.Log($"Saving to {Path()}");
        }
    }

    LevelData CreateLevelData()
    {
        LevelData levelData = new LevelData();
        levelData.ground = ground.GetMaterial();
        levelData.blocks = new Block[blocks.Count];
        for (int i = 0; i < blocks.Count; ++i)
        {
            Vector3 position = blocks[i].transform.position;
            Quaternion orientation = blocks[i].transform.rotation;
            levelData.blocks[i] = new Block(position, orientation);
        }
        return levelData;
    }

    public void Save()
    {
        LevelData levelData = CreateLevelData();
        string json = levelData.SaveToJSON();
        SaveJSON(json);
    }

    void CreateNewBlock(Vector3 position, Quaternion orientation)
    {
        Transform block = Instantiate(blockPrefab, position, orientation, transform);
        blocks.Add(block);
    }

    void Update()
    {
        bool spawn = Input.GetMouseButtonUp(1);
        if (spawn)
        {
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;
            float z = 10f;
            Vector3 position = camera.ScreenToWorldPoint(new Vector3(x, y, z));
            position.y = Mathf.Max(2f, position.y);
            Quaternion orientation = Quaternion.identity;
            CreateNewBlock(position, orientation);
        }
    }
}
