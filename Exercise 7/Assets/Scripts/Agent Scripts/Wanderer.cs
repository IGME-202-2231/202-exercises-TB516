using UnityEngine;

public class Wanderer : Agent
{
    [SerializeField] private float _boundsWeight = 10;
    protected override void CalcSteeringForces()
    {
        _totalForce += Wander(2, 1.5f);
        _totalForce += StayInBounds(0, _boundsWeight);
        _totalForce += Seperate(2.5f);
        _totalForce += Cohesion(8);
        _totalForce += Alignment(2f);
    }
    private void OnDrawGizmosSelected()
    {
        Vector3 futurePos = GetFuturePosition(2);
        Vector3 steeringPoint = new(futurePos.x + Mathf.Cos(_wanderAngle) * 1, futurePos.y + Mathf.Sin(_wanderAngle) * 1);

        Gizmos.DrawWireSphere(futurePos, 1);
        Gizmos.DrawSphere(steeringPoint, .1f);
        Gizmos.DrawLine(transform.position, futurePos);
        Gizmos.DrawLine(transform.position, steeringPoint);
    }
}
