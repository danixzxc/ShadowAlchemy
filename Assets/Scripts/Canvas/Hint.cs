using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hint : MonoBehaviour
{
    private float _currentTimeScale;
    public void ShowHint(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _currentTimeScale = Time.timeScale;
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        if (callbackContext.canceled)
        {
            gameObject.SetActive(false);
            Time.timeScale = _currentTimeScale;
        }
    }
}
