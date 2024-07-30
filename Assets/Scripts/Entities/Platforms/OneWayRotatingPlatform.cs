using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OneWayRotatingPlatform : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _targetAngle;
    [SerializeField]
    private float _time;

    public bool moving { get; set; } = false;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
        if (moving)
        {
            if (Mathf.Abs(_rigidbody.rotation - _targetAngle )> 1f)
                _rigidbody.rotation +=  _targetAngle / _time * Time.fixedDeltaTime;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        var rigidbody = collision.collider.GetComponent<Rigidbody2D>();
        rigidbody.position = (rigidbody.position + _rigidbody.velocity * Time.fixedDeltaTime);
    }

}
