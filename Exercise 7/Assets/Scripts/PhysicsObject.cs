using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    static Vector3 s_gravity = Vector3.down * 9.81f;
    static float s_frictionCoef = .8f;

    Vector3 _position;
    Vector3 _velocity;

    [SerializeField] Vector3 _acceleration;
    [SerializeField] float _mass = 1;
    [SerializeField] float _maxSpeed = 10;
    [SerializeField] bool _useFriction;
    [SerializeField] bool _useGravity;
    [SerializeField] bool _bounces = true;

    public float MaxSpeed => _maxSpeed;
    public Vector3 Velocity => _velocity;

    void Update()
    {
        _position = transform.position;

        if (_useGravity) ApplyGravity();
        if (_useFriction) ApplyFriction();

        _velocity += _acceleration * Time.deltaTime;
        _velocity = Vector3.ClampMagnitude(_velocity, _maxSpeed);

        _position += _velocity * Time.deltaTime;

        if (_bounces) Bounce();

        transform.position = _position;

        _acceleration = Vector3.zero;
    }

    private void ApplyGravity()
    {
        _acceleration += s_gravity;
    }

    private void ApplyFriction()
    {
        Vector3 friction = _velocity * -1;
        friction.Normalize();

        friction *= s_frictionCoef;

        Debug.Log(friction);

        ApplyForce(friction);
    }

    private void Bounce()
    {
        if (_position.x <= CollisionManager.ScreenMin.x)
        {
            _velocity.x *= -1;
            _position.x = CollisionManager.ScreenMin.x;
        }
        else if (_position.x >= CollisionManager.ScreenMax.x)
        {
            _velocity.x *= -1;
            _position.x = CollisionManager.ScreenMax.x;
        }

        if (_position.y <= CollisionManager.ScreenMin.y)
        {
            _velocity.y *= -1;
            _position.y = CollisionManager.ScreenMin.y;
        }
        else if (_position.y >= CollisionManager.ScreenMax.y)
        {
            _velocity.y *= -1;
            _position.y = CollisionManager.ScreenMax.y;
        }
    }

    public void ApplyForce(Vector3 force)
    {
        _acceleration += force / _mass;
    }

    public void StopMoving()
    {
        _acceleration = Vector3.zero;
        _velocity = Vector3.zero;
    }
}
