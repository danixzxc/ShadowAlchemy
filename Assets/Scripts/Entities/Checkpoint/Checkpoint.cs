using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    private int ID;
    private bool _active = false;

    [SerializeField]
    private Sprite unlit;
    [SerializeField]
    private Sprite lit;
    private SpriteRenderer spriteRenderer;

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

    void OnTriggerEnter2D(Collider2D collider){
        PlayerCheckpointManager playerCheckpointManager = collider.GetComponent<PlayerCheckpointManager>();
        if(playerCheckpointManager != null){
            playerCheckpointManager.UpdateID(ID);
            Active = true;
        }
    }
}
