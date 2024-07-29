using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Vector2 _leftPoint;
    private Vector2 _rightPoint;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private bool _startFromLeftPoint;
    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 _currentPoint;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //_animator = GetComponent<Animator>();
        _lineRenderer = GetComponent<LineRenderer>();
        if (_lineRenderer.GetPosition(0).x < _lineRenderer.GetPosition(1).x)
        {
            _leftPoint = _lineRenderer.GetPosition(0);
            _rightPoint = _lineRenderer.GetPosition(1);
        }
        else
        {
            _leftPoint = _lineRenderer.GetPosition(1);
            _rightPoint = _lineRenderer.GetPosition(0);
        }
        _lineRenderer.enabled = false;
        if(_startFromLeftPoint)
            _currentPoint = _leftPoint;
        else
            _currentPoint = _rightPoint;

        //_animator.SetBool("isRunning", true);
    }

    void Update()
    {
        Vector2 point = _currentPoint - new Vector2(transform.position.x, transform.position.y);
        if(_currentPoint == _leftPoint)
        {
            _rb.velocity = new Vector2(-_speed, 0);
        }
        if (_currentPoint == _rightPoint)
        {
            _rb.velocity = new Vector2(_speed, 0);
        }
        if (Vector2.Distance(transform.position, _currentPoint) < 1.5f && _currentPoint == _rightPoint)
        {
            Flip();
        }
        if (Vector2.Distance(transform.position, _currentPoint) < 1.5f && _currentPoint == _leftPoint)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        if(_currentPoint == _rightPoint)
            _currentPoint = _leftPoint;
        else if (_currentPoint == _leftPoint)
            _currentPoint = _rightPoint;
    }

    public void Aggro()
    {
        if (_currentPoint == _rightPoint)
        {
            _currentPoint = _leftPoint;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
