using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    e,
    none,
    q,
    w
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Gesture", order = 2)]

public class Gesture : ScriptableObject
{
    public Type type;
    public Sprite sprite;
    public string correspondingInput;
    public bool Compare(Gesture other)
    {
        if (other.type == this.type)
            return true;
        else
            return false;
    }
}