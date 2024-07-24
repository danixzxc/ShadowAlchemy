using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayerState : MonoBehaviour
{
    public SpriteRenderer upperSprite;
    public SpriteRenderer lowerSprite;
    
    public void ChangeUpperColor(Color color){
        upperSprite.color = color;
    }
    public void ChangeLowerColor(Color color){
        lowerSprite.color = color;
    }
    
}
