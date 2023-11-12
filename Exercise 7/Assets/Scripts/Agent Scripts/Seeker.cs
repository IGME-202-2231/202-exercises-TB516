using UnityEngine;

public class Seeker : Agent
{
    [SerializeField] GameObject _target;
    protected override void CalcSteeringForces()
    {
        _totalForce += Seek(_target);
    }
}
