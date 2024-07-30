using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private int ID;
    private bool _active = false;

    [SerializeField]
    private Sprite unlit;
    [SerializeField]
    private Sprite lit;
    private SpriteRenderer spriteRenderer;

    private CheckpointManager _checkpointManager;

    public bool Active{
        get => _active;
        set{
            if(_active != value){
                _active = value;
                if(_active){
                    OnActivation?.Invoke();
                }
            }
            spriteRenderer.sprite = _active ? lit : unlit;
        }
    }


    public UnityEvent OnActivation;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _checkpointManager = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();
        if(_checkpointManager.GetId() >= ID)
            Active = true;
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(_checkpointManager != null){
            _checkpointManager.UpdateID(ID);
            Active = true;
        }
    }
}
