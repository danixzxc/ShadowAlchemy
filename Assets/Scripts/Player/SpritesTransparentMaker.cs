using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesTransparentMaker : MonoBehaviour
{
    public float transparency = 0.5f;   
    public List<SpriteRenderer> sprites;
    private bool _transparent;
    public bool transparent{
        get {return _transparent;}
        set {
            _transparent = value;
            if (_transparent){
                foreach (var sprite in sprites){
                    sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, transparency);
                }
            }
            else {
                foreach (var sprite in sprites){
                    sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1.0f);
                }
            }
        }
    }
}
