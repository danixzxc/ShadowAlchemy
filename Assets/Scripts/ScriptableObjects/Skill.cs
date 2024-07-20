using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Skill", order = 1)]

public class Skill : ScriptableObject

{   
    public new string name;
    public string id;
    public Sprite sprite;
    public Type[] combination = new Type[3];
    
    
    public bool isValid(Type[] types)
    {
        for (int i = 0; i < combination.Length; i++)
            if (combination[i] != types[i])
                return false;
        return true;
    }
}