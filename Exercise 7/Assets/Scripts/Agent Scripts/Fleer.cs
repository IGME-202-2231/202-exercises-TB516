using UnityEngine;

public class Fleer : Agent
{
    [SerializeField] GameObject _target;
    protected override void CalcSteeringForces()
    {
        _physicsObject.ApplyForce(Flee(_target));
    }
}
