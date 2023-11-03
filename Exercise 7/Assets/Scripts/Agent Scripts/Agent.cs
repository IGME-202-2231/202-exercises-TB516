using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [SerializeField] protected PhysicsObject _physicsObject;
    [SerializeField] float _maxForce = 10;

    private void Update()
    {
        CalcSteeringForces();
        FaceDirection();
    }

    private void FaceDirection()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _physicsObject.Velocity);
    }

    protected abstract void CalcSteeringForces();

    protected Vector3 Seek(Vector3 targetPos)
    {
        //Get desired direction, normalize and multiply by speed
        //Subtract velocity from that, then clamp it to max force
        return Vector3.ClampMagnitude(
            (((targetPos - transform.position).normalized * _physicsObject.MaxSpeed) - _physicsObject.Velocity),
            _maxForce);
    }

    protected Vector3 Seek(GameObject gameObject)
    {
        return Seek(gameObject.transform.position);
    }

    protected Vector3 Flee(Vector3 targetPos)
    {
        return Vector3.ClampMagnitude(
            (((transform.position - targetPos).normalized * _physicsObject.MaxSpeed) - _physicsObject.Velocity),
            _maxForce);
    }

    protected Vector3 Flee(GameObject gameObject)
    {
        return Flee(gameObject.transform.position);
    }
}
