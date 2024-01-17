using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Block
{
    public Vector3 position;
    public Quaternion orientation;

    public Block(Vector3 position, Quaternion orientation)
    {
        this.position = position;
        this.orientation = orientation;
    }
}
