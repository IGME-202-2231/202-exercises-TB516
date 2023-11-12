using UnityEngine;

public class Fleer : Agent
{
    [SerializeField] GameObject _target;
    protected override void CalcSteeringForces()
    {
        _totalForce += Flee(_target);
    }
}
