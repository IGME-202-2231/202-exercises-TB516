using UnityEngine;

public class CircleCollider : MonoBehaviour
{
    [SerializeField] protected float _circleRadius = 2;

    public float Radius => _circleRadius;

    public virtual bool IsCollidingWith(CircleCollider entity)
    {
        return (transform.position - entity.transform.position).magnitude <= _circleRadius + entity._circleRadius;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _circleRadius);
    }
}
