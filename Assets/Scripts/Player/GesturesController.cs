using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GesturesController : MonoBehaviour
{
    private int _gestureIndex = 0;
    private Gesture[] _gestures = new Gesture[3];
    public UnityEvent<Gesture[]> OnGesturesChanged;
    public UnityEvent<Skill> OnSkillChanged;

    // 0 fist 1 middlefinger 2 none 3 pinky

    private void Awake()
    {
        OnGesturesChanged.AddListener(CreateSkill);
    }

    private void Start()
    {
        for (int i = 0; i < _gestures.Length; i++)
        {
            _gestures[i] = CombinationManager.Instance.GetGesture((int)Type.none);
        }
        OnGesturesChanged.Invoke(_gestures);
    }

    private int FindSlotByType(Type type)
    {
        for (int i = 0; i < _gestures.Length; i++)
        {
            if (_gestures[i].type == type)
                return i;
        }
        return -1;
    }

    private void AddGesture(int gestureNumber)
    {
        _gestureIndex = FindSlotByType(Type.none);
        if (_gestureIndex != -1)
        {
            _gestures[_gestureIndex] = CombinationManager.Instance.GetGesture(gestureNumber);
            OnGesturesChanged.Invoke(_gestures);
        }
    }

    private void DeleteGesture(Type type)
    {
        _gestureIndex = FindSlotByType(type);
        _gestures[_gestureIndex] = CombinationManager.Instance.GetGesture(2);

        //сместить жесты влево
        for (_gestureIndex++; _gestureIndex < _gestures.Length; _gestureIndex++)
        {
            _gestures[_gestureIndex - 1] = CombinationManager.Instance.GetGesture((int)_gestures[_gestureIndex].type);
            _gestures[_gestureIndex] = CombinationManager.Instance.GetGesture(2);
        }
        OnGesturesChanged.Invoke(_gestures);
    }

    public void AddFirstGesture(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AddGesture(0);
        }
        if (context.canceled)
        {
            DeleteGesture(Type.fist);
        }
    }

    public void AddSecondGesture(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AddGesture(1);
        }
        if (context.canceled)
        {
            DeleteGesture(Type.middleFinger);
        }
    }
    public void AddThirdGesture(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AddGesture(3);
        }
        if (context.canceled)
        {
            DeleteGesture(Type.pinky);
        }
    }

    public void CreateSkill(Gesture[] gestures)
    {
        Type[] temp = new Type[3];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = gestures[i].type;
        }
        var skill = CombinationManager.Instance.CombineSkill(temp);
        if (skill != null)
        {
            Debug.Log(skill.name);
            OnSkillChanged.Invoke(skill);
        }
    }

    public void CastSkill()
    {
        Debug.Log("Casting skill");
    }
}
