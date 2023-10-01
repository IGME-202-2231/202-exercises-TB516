using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    public static bool UseCircleColider = false;

    [SerializeField] public SpriteRenderer _renderer;

    [SerializeField] private Vector2 _rectSize;

    [SerializeField] private float _radius = 1f;

    [SerializeField] private bool _useRendererBounds = true;

    private bool _isColliding = false;

    public Vector2 RectMin => (Vector2)transform.position - (_rectSize / 2);
    public Vector2 RectMax => (Vector2)transform.position + (_rectSize / 2);
    public float Radius => _radius;
    public bool IsColiding { get { return _isColliding; } set { _isColliding = value; } }

    // Update is called once per frame
    void Update()
    {
        if (_useRendererBounds)
        {
            _rectSize = _renderer.bounds.size;
        }

        if (_isColliding)
        {
            _renderer.color = Color.red;
        }
        else
        {
            _renderer.color = Color.white;
        }
    }

    private void OnDrawGizmos()
    {
        switch (UseCircleColider)
        {
            case true:
                Gizmos.DrawWireSphere(_renderer.bounds.center, _radius);
                break;
            case false:
                Gizmos.DrawWireCube(_renderer.bounds.center, _rectSize);
                break;
        }
        
    }
}
