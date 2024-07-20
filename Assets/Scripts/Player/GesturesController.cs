using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GesturesController : MonoBehaviour
{
    private int _gestureIndex = 0;
    private Type[] _gestures = new Type[3];

    public void AddFirstGesture(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
        Debug.Log("FirstSkillAdded");
            _gestures[_gestureIndex] = RecipeManager.Instance.GetGesture(0).type;
            _gestureIndex++;
            if (_gestureIndex == 3)
                _gestureIndex -= 3;
        }
    }
    public void AddSecondGesture(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
        Debug.Log("SecondSkillAdded");
            _gestures[_gestureIndex] = RecipeManager.Instance.GetGesture(1).type;
            _gestureIndex++;
            if (_gestureIndex == 3)
                _gestureIndex -= 3;
        }
    }
    public void AddThirdGesture(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
        Debug.Log("ThirdSkillAdded");
            _gestures[_gestureIndex] = RecipeManager.Instance.GetGesture(2).type;
            _gestureIndex++;
            if (_gestureIndex == 3)
                _gestureIndex -= 3;
        }
    }

    public void CastSpell(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
        Debug.Log("SkillCasted");
            Debug.Log(RecipeManager.Instance.CraftItem(_gestures).name);
        }
    }
}
