using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingEnemy : MonoBehaviour
{

    [SerializeField]
    private bool _startWatchingLeft;
    private bool _currentlyWatchingLeft;

    private void Start()
    {
        if (_startWatchingLeft)
            _currentlyWatchingLeft = true;
        else
        {
            TurnRight();
        }
    }

    public void TurnLeft()
    {
        if (!_currentlyWatchingLeft)
        {
            Flip();
            _currentlyWatchingLeft = true;
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void TurnRight()
    {
        Flip();
        _currentlyWatchingLeft = false;
    }
}
