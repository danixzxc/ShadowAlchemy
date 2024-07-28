using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Lever : MonoBehaviour
{
    public enum Position {Left, Right}
    [SerializeField]
    private Position startingPosition = Position.Left;
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
            }
            else {
                OnTurnedRight?.Invoke();
            }
        }
    }

    void Awake(){
        CurrentPosition = startingPosition;
    }

    void Turn(Position newPosition){
        CurrentPosition = newPosition;
    }

    void Switch(){
        CurrentPosition = OppositePosition(CurrentPosition);
    }

    static public Position OppositePosition(Position pos){
        return pos == Position.Left ? Position.Right : Position.Left;
    }
}
