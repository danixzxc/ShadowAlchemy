using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ParallaxLayer", order = 2)]

public class ParallaxLayerData : ScriptableObject
{
    public List<Sprite> sprites;
    public float parallaxFactor;
}
