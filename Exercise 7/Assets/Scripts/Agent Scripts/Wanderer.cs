using UnityEngine;

public class Wanderer : Agent
{
    [SerializeField] private float _boundsWeight = 10;
    protected override void CalcSteeringForces()
    {
        _totalForce += Wander();
        _totalForce += StayInBounds(1, _boundsWeight);
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
