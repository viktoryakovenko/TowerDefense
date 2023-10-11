using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class BackgroundScroller : MonoBehaviour
{
    [SerializeField, Range(-0.2f, 0.2f)] private float _xSpeed, _ySpeed;

    private RawImage _scrollingImage;
    private Vector2 _moveSpeed;

    private void Start() 
    {
        _scrollingImage = GetComponent<RawImage>();
        _moveSpeed = new Vector2(_xSpeed, _ySpeed);
    }

    private void Update()
    {
        _scrollingImage.uvRect = new Rect(_scrollingImage.uvRect.position + _moveSpeed * Time.deltaTime, _scrollingImage.uvRect.size);
    }
}