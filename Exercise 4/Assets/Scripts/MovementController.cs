using UnityEngine;

public class MovementController : MonoBehaviour
{
    private float _cameraHeight;
    private float _cameraWidth;

    private Vector3 _direction;
    private Vector3 _position;
    private Vector3 _velocity;
    private const float _speed = 4;

    public Vector3 Direction
    {
        get { return _direction; }
        set { _direction = value.normalized; }
    }

    private void Awake()
    {
        _cameraHeight = Camera.main.orthographicSize * 2f;
        _cameraWidth = _cameraHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (_direction != Vector3.zero) transform.rotation = Quaternion.LookRotation(Vector3.forward, _direction);

        _velocity = _speed * _direction * Time.deltaTime;
        _position += _velocity;

        #region Screen Wrapping stuff
        if (_position.x > _cameraWidth / 2)
        {
            _position.x -= _cameraWidth;
        }
        else if (_position.x < -(_cameraWidth / 2))
        {
            _position.x += _cameraWidth;
        }

        if (_position.y > _cameraHeight / 2)
        {
            _position.y -= _cameraHeight;
        }
        else if (_position.y < -(_cameraHeight / 2))
        {
            _position.y += _cameraHeight;
        }
        #endregion

        transform.position = _position;
    }
}
