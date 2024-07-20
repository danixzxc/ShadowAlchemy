using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GesturesDisplay : MonoBehaviour
{
    // [SerializeField] private List<Image> _images;

    private GesturesController _gesturesController;

    [SerializeField] private Image[] _gestureImages = new Image[3];
    [SerializeField] private Image _skillImage;

    private void Awake()
    {
        _gesturesController = FindObjectOfType<GesturesController>();

        if (_gesturesController != null)
        {
            _gesturesController.OnGesturesChanged.AddListener(DisplayGestures);
            _gesturesController.OnSkillChanged.AddListener(DisplaySkill);
        }
    }

    private void OnDestroy()
    {
        if (_gesturesController != null)
        {
            _gesturesController.OnGesturesChanged.RemoveListener(DisplayGestures);
            _gesturesController.OnSkillChanged.AddListener(DisplaySkill);
        }
    }

    private void DisplayGestures(Gesture[] gestures)
    {
        for(int i = 0; i <  gestures.Length; i++) 
        {
            _gestureImages[i].sprite = gestures[i].sprite;
        }
    }

    private void DisplaySkill(Skill skill)
    {

        _skillImage.sprite = skill.sprite;
        
    }

}
