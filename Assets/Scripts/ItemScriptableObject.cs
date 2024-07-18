using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemScriptableObject", order = 1)]

public class ItemScriptableObject : ScriptableObject
{
    public string name;
    public string id;
    public Sprite sprite;
    public List<ItemScriptableObject> recepie;
}