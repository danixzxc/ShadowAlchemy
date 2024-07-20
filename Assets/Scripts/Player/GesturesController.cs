using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GesturesController : MonoBehaviour
{
    private int _gestureIndex = 0;
    private Gesture[] _gestures = new Gesture[3];
    public UnityEvent<Gesture[]> OnGesturesChanged;
    public UnityEvent<Skill> OnSkillChanged;

    private void Start()
    {
        for(int i = 0; i < _gestures.Length; i++)
        {
            _gestures[i] = RecipeManager.Instance.GetGesture(2);
        }
            OnGesturesChanged.Invoke(_gestures);
    }
    public void AddFirstGesture(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
        Debug.Log("FirstGestureAdded");
            _gestures[_gestureIndex] = RecipeManager.Instance.GetGesture(0);
            _gestureIndex++;
            if (_gestureIndex == 3)
                _gestureIndex -= 3;
            OnGesturesChanged.Invoke(_gestures);
        }
    }
    public void AddSecondGesture(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
        Debug.Log("SecondGestureAdded");
            _gestures[_gestureIndex] = RecipeManager.Instance.GetGesture(1);
            _gestureIndex++;
            if (_gestureIndex == 3)
                _gestureIndex -= 3;
            OnGesturesChanged.Invoke(_gestures);
        }
    }
    public void AddThirdGesture(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
        Debug.Log("ThirdGestureAdded");
            _gestures[_gestureIndex] = RecipeManager.Instance.GetGesture(3);
            _gestureIndex++;
            if (_gestureIndex == 3)
                _gestureIndex -= 3;
            OnGesturesChanged.Invoke(_gestures);
        }
    }

    public void CastSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Type[] temp = new Type[3];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = _gestures[i].type;
            }
            var skill = RecipeManager.Instance.CraftItem(temp);
            if (skill != null)
            {
                Debug.Log(skill.name);
                OnSkillChanged.Invoke(skill);
            }
        }
    }
}
