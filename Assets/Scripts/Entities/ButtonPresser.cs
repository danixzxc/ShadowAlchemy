using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPresser : MonoBehaviour
{
    private bool _canPress = true;
    public bool CanPress{
        get {return _canPress;}
        set{
            _canPress = value;
        }
    }
    
}
