using UnityEngine;

public class Seeker : Agent
{
    [SerializeField] GameObject _target;
    protected override void CalcSteeringForces()
    {
        _physicsObject.ApplyForce(Seek(_target));
    }
}
