using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class BindingHinter : MonoBehaviour
{
    private PlayerInput playerInput;
    [TextAreaAttribute]
    public string text;
    public string actionMap;
    public List<string> actions;

    public TMP_Text _textComponent;


    void Start()
    {
        playerInput = FindFirstObjectByType<PlayerInput>();
        UpdateText(playerInput);
        playerInput.controlsChangedEvent.AddListener(UpdateText);
    }

    private void UpdateText(PlayerInput newPlayerInput){
        playerInput = newPlayerInput;
        _textComponent.text = Format(text, playerInput, actionMap, actions); 
    }

    static public string Format(string text, PlayerInput playerInput, string actionMap, List<string> actions){
        List<string> buttons = new List<string>();
        string scheme = playerInput.currentControlScheme;
        InputActionAsset actionAsset = playerInput.actions;
        foreach(string action in actions){
            var bindings = actionAsset.FindActionMap(actionMap).FindAction(action).bindings;
            foreach(var binding in bindings){
                if(binding.groups.Contains(scheme)){
                    buttons.Add(binding.ToDisplayString());
                    break;
                }
                
            }
        }
        return string.Format(text, buttons.ToArray());
    }

    void OnDestroy(){
        playerInput.controlsChangedEvent.RemoveListener(UpdateText);
    }
}
