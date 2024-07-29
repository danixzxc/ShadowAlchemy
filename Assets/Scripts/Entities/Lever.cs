using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Lever : MonoBehaviour
{
    public enum Position {Left, Right}
    [SerializeField]
    private Position startingPosition = Position.Right;
    public UnityEvent<Position> OnPositionChanged;
    public UnityEvent OnTurnedLeft;
    public UnityEvent OnTurnedRight;
    

    private Position _position;
    public Position CurrentPosition{
        get{return _position;}
        set{
            _position = value;
            OnPositionChanged?.Invoke(_position);
            if(_position == Position.Left){
                OnTurnedLeft?.Invoke();
                transform.localScale = new Vector3(- Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else {
                OnTurnedRight?.Invoke();
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    void Awake(){
        CurrentPosition = startingPosition;
    }

    public void Turn(Position newPosition){
        CurrentPosition = newPosition;
    }

    public void Switch(){
        CurrentPosition = OppositePosition(CurrentPosition);
    }

    static public Position OppositePosition(Position pos){
        return pos == Position.Left ? Position.Right : Position.Left;
    }

    void OnTriggerEnter2D(Collider2D collider){
        LeverToucher toucher = collider.GetComponent<LeverToucher>();
        if (toucher != null){
            CurrentPosition = toucher.whichWay;
            toucher.OnLeverTouched?.Invoke();
        }
    }
}
