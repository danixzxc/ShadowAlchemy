using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GesturesController : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacteristics _playerCharacteristics;

    private int _gestureIndex = 0;
    private Gesture[] _gestures = new Gesture[3];
    public UnityEvent<Gesture[]> OnGesturesChanged;
    public UnityEvent<SkillData> OnSkillChanged;

    private Skill _currentSkill;

    private float _angle = 0.0f;
    public float Angle{
        get{return _angle;}
        set{
            _angle = value;
        }
    }

    private void Awake()
    {
        OnGesturesChanged.AddListener(CreateSkill);
    }

    private void OnDestroy()
    {
        OnGesturesChanged.RemoveListener(CreateSkill);
    }

    private void Start()
    {
        for (int i = 0; i < _gestures.Length; i++)
        {
            _gestures[i] = CombinationManager.Instance.GetGesture((int)Type.none);
        }
        OnGesturesChanged?.Invoke(_gestures);
        _currentSkill = new Skill();
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
        _gestures[_gestureIndex] = CombinationManager.Instance.GetGesture((int)Type.none);

        for (_gestureIndex++; _gestureIndex < _gestures.Length; _gestureIndex++)
        {
            _gestures[_gestureIndex - 1] = CombinationManager.Instance.GetGesture((int)_gestures[_gestureIndex].type);
            _gestures[_gestureIndex] = CombinationManager.Instance.GetGesture((int)Type.none);
        }
        OnGesturesChanged.Invoke(_gestures);
    }

    public void AddFirstGesture(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AddGesture((int)Type.q);
        }
        if (context.canceled)
        {
            DeleteGesture(Type.q);
        }
    }

    public void AddSecondGesture(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AddGesture((int)Type.w);
        }
        if (context.canceled)
        {
            DeleteGesture(Type.w);
        }
    }
    public void AddThirdGesture(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AddGesture((int)Type.e);
        }
        if (context.canceled)
        {
            DeleteGesture(Type.e);
        }
    }

    public void CreateSkill(Gesture[] gestures)
    {
        Type[] temp = new Type[3];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = gestures[i].type;
        }
        _currentSkill = CombinationManager.Instance.CombineSkill(temp);
        if (_currentSkill != null)
        {
            OnSkillChanged.Invoke(_currentSkill.data);
        }
    }

    public void CastSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
              _currentSkill.CastSkill(_angle, this.gameObject);
        }

        if (context.canceled)
        {
              _currentSkill.Cancel();
        }
    }
}
