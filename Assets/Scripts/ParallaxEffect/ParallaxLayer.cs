using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField]
    private ParallaxLayerData _data;

    private SpriteRenderer _parentObjectSpriteRenderer;
    private SpriteRenderer _childObjectSpriteRenderer;

    private float _startPosition;

    private GameObject _camera;

    private float _length;

    private void Start()
    {
        _startPosition = transform.position.x;
        _camera = FindObjectOfType<Camera>().gameObject;
        _parentObjectSpriteRenderer = GetComponent<SpriteRenderer>();
        _childObjectSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _length = _parentObjectSpriteRenderer.bounds.size.x;

        _childObjectSpriteRenderer.sprite = _data.sprites[Random.Range(0, _data.sprites.Count)];
    }

    private void FixedUpdate()
    {
        float distance = _camera.transform.position.x * _data.parallaxFactor;
        float movement = _camera.transform.position.x * (1 - _data.parallaxFactor);
        
        transform.position = new Vector3(_startPosition + distance, transform.position.y, transform.position.z);

        if(movement > _startPosition + _length)
        {
            _parentObjectSpriteRenderer.sprite = _childObjectSpriteRenderer.sprite;
            _startPosition += _length;
            _childObjectSpriteRenderer.sprite = _data.sprites[Random.Range(0, _data.sprites.Count)];
        }
    }

}
