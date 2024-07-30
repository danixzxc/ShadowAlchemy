using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OneWayMovingPlatform : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Rigidbody2D _rigidbody;
    private Vector2 _targetPosition;
    [SerializeField]
    private float _time;

    private float _fullDistanceX;
    private float _fullDistanceY;
    public bool moving { get; set; } = false;

    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _lineRenderer = GetComponent<LineRenderer>();

        _targetPosition = _lineRenderer.GetPosition(0);
        _fullDistanceX = _targetPosition.x - transform.position.x;
        _fullDistanceY = _targetPosition.y - transform.position.y;

        _lineRenderer.enabled = false;
    }
    void FixedUpdate()
    {
        if (moving)
        {
            _rigidbody.velocity = new Vector2(_fullDistanceX / _time, _fullDistanceY / _time);
            if (Vector2.Distance(transform.position, _targetPosition) < 1.5f)
                _rigidbody.velocity = new Vector2(0, 0);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        var rigidbody = collision.collider.GetComponent<Rigidbody2D>();
        rigidbody.position = (rigidbody.position + _rigidbody.velocity * Time.fixedDeltaTime);
    }

}
