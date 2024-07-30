using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWaysMovingPlatform : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Rigidbody2D _rigidbody;
    private Vector2 _leftTargetPosition;
    private Vector2 _rightTargetPosition;
    [SerializeField]
    private float _timeFromStartToFirstPoint;
    [SerializeField]
    private float _timeFromOnePointToAnother;
    [SerializeField]
    private bool _startFromLeftPoint;

    private Vector2 _currentTargetPosition;

    private float _time;
    private Vector2 _distancePerSecond;

    public bool moving { get; set; } = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _lineRenderer = GetComponent<LineRenderer>();

        if (_lineRenderer.GetPosition(0).x < _lineRenderer.GetPosition(1).x)
        {
            _leftTargetPosition = _lineRenderer.GetPosition(0);
            _rightTargetPosition = _lineRenderer.GetPosition(1);
        }
        else
        {
            _leftTargetPosition = _lineRenderer.GetPosition(1);
            _rightTargetPosition = _lineRenderer.GetPosition(0);
        }
        if(_startFromLeftPoint)
        {
            _currentTargetPosition = _leftTargetPosition;
        }
        else
        {
            _currentTargetPosition = _rightTargetPosition;
        }
        _time = _timeFromStartToFirstPoint;
        _distancePerSecond = (_currentTargetPosition - (Vector2)transform.position) / _time;
    }
    void FixedUpdate()
    {
        if (moving)
        {
            _rigidbody.velocity = new Vector2(_distancePerSecond.x, _distancePerSecond.y);
            if (Vector2.Distance(transform.position, _currentTargetPosition) < 1.5f
                && _currentTargetPosition == _leftTargetPosition)
            {
                _currentTargetPosition = _rightTargetPosition;
                Reset();
            }
            if (Vector2.Distance(transform.position, _currentTargetPosition) < 1.5f
                && _currentTargetPosition == _rightTargetPosition)
            {
                _currentTargetPosition = _leftTargetPosition;
                Reset();
            }
        }
    }

    private void Reset()
    {
        _time = _timeFromOnePointToAnother;
        _distancePerSecond = (_currentTargetPosition - (Vector2)transform.position) / _time;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        var rigidbody = collision.collider.GetComponent<Rigidbody2D>();
        rigidbody.position = (rigidbody.position + _rigidbody.velocity * Time.fixedDeltaTime);
    }

}
