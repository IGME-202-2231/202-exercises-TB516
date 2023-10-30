using System;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    static Vector3 s_gravity = Vector3.down * 9.81f;
    static float s_frictionCoef = .8f;

    Vector3 _position;
    Vector3 _velocity;
    Vector3 _direction;
    Vector3 _acceleration;

    [SerializeField] float _mass = 1;
    [SerializeField] float _maxSpeed = 10;
    [SerializeField] bool _useFriction;
    [SerializeField] bool _useGravity;

    Vector2 ScreenMax
    {
        get
        {
            return new(
                Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect,
                Camera.main.transform.position.y + Camera.main.orthographicSize
                );
        }
    }
    Vector2 ScreenMin
    {
        get
        {
            return new(
                Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect,
                Camera.main.transform.position.y - Camera.main.orthographicSize
                );
        }
    }

    void Start()
    {
        _position = transform.position;
    }

    void Update()
    {
        if (_useGravity) ApplyGravity();
        if (_useFriction) ApplyFriction();

        _velocity += _acceleration * Time.deltaTime;
        _velocity = Vector3.ClampMagnitude(_velocity, _maxSpeed);

        _position += _velocity * Time.deltaTime;

        Bounce();

        _direction = _velocity.normalized;

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
        if (_position.x <= ScreenMin.x)
        {
            _velocity.x *= -1;
            _position.x = ScreenMin.x;
        }
        else if (_position.x >= ScreenMax.x)
        {
            _velocity.x *= -1;
            _position.x = ScreenMax.x;
        }

        if (_position.y <= ScreenMin.y)
        {
            _velocity.y *= -1;
            _position.y = ScreenMin.y;
        }
        else if (_position.y >= ScreenMax.y)
        {
            _velocity.y *= -1;
            _position.y = ScreenMax.y;
        }
    }

    public void ApplyForce(Vector3 force)
    {
        _acceleration += force / _mass;
    }
}
