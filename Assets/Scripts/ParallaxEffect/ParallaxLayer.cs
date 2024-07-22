using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;
    private float _startPosition;

    private GameObject _camera;

    private float _length;

    private void Start()
    {
        _startPosition = transform.position.x;
        _camera = FindObjectOfType<Camera>().gameObject;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    private void FixedUpdate()
    {
        float distance = _camera.transform.position.x * parallaxFactor;
        float movement = _camera.transform.position.x * (1 - parallaxFactor);
        
        transform.position = new Vector3(_startPosition + distance, transform.position.y, transform.position.z);

        if(movement > _startPosition + _length)
        {
            _startPosition += _length;
        }
    }

}
