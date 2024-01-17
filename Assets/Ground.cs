using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public List<Material> materials;
    new public Renderer renderer;
    int index = 0;

    void Start()
    {
        Clear();
    }

    void ApplyMaterial()
    {
        renderer.material = materials[index];
    }

    public void Clear()
    {
        index = 0;
        ApplyMaterial();
    }

    public void SetMaterial(string name)
    {
        index = materials.FindIndex((material) => material.name == name);
        if (index < 0)
        {
            index = 0;
        }
        ApplyMaterial();
    }

    public void NextMaterial()
    {
        index++;
        if (index >= materials.Count)
        {
            index = 0;
        }
        ApplyMaterial();
    }

    public string GetMaterial()
    {
        return materials[index].name;
    }

    public void OnMouseUpAsButton()
    {
        NextMaterial();
    }
}
