using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxLayer : MonoBehaviour
{

    private float _startPosition;
    [SerializeField]
    private GameObject _camera;
    private float _length;
    [SerializeField]
    private float _parallaxEffect;

    private void Start()
    {
        _startPosition = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float distance = _camera.transform.position.x * _parallaxEffect;
        float movement = _camera.transform.position.x * (1 - _parallaxEffect);

        transform.position = new Vector3(_startPosition + distance, transform.position.y, transform.position.z);

        if (movement > _startPosition + _length)
        {
            _startPosition += _length;
        }
    }
}
