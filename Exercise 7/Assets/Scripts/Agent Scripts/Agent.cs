using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [SerializeField] protected PhysicsObject _physicsObject;
    [SerializeField] float _maxForce = 10;
    [SerializeField] protected AgentManager _agentManager;
    [SerializeField] protected SpriteRenderer _renderer;

    protected float _wanderAngle = 0;
    [SerializeField] float _perlinOffset = 100;

    protected Vector3 _totalForce;

    protected void Start()
    {
        _wanderAngle = Random.Range(0,360);
    }

    private void Update()
    {
        _totalForce = Vector3.zero;

        CalcSteeringForces();
        FaceDirection();

        _totalForce = Vector3.ClampMagnitude(_totalForce, _maxForce);
        _physicsObject.ApplyForce(_totalForce);
    }

    private void FaceDirection()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _physicsObject.Velocity);
    }

    protected abstract void CalcSteeringForces();

    protected Vector3 Seek(Vector3 targetPos, float weight = 1)
    {
        //Get desired direction, normalize and multiply by speed
        //Subtract velocity from that, then clamp it to max force
        return weight * ((targetPos - transform.position).normalized * _physicsObject.MaxSpeed) - _physicsObject.Velocity;
    }

    protected Vector3 Seek(GameObject gameObject, float weight = 1)
    {
        return Seek(gameObject.transform.position, weight);
    }

    protected Vector3 Flee(Vector3 targetPos, float weight = 1)
    {
        return weight * ((transform.position - targetPos).normalized * _physicsObject.MaxSpeed) - _physicsObject.Velocity;
    }

    protected Vector3 Flee(GameObject gameObject, float weight = 1)
    {
        return Flee(gameObject.transform.position, weight);
    }

    protected Vector3 Wander(float wanderRadius = .5f, float weight = 1)  
    {
        Vector3 futurePos = GetFuturePosition(1);

        _wanderAngle += (0.5f - Mathf.PerlinNoise(transform.position.x * 0.1f + _perlinOffset, transform.position.y * .1f + _perlinOffset)) * Mathf.PI * Time.deltaTime;

        return Seek(new Vector3(futurePos.x + Mathf.Cos(_wanderAngle) * wanderRadius, futurePos.y + Mathf.Sin(_wanderAngle) * wanderRadius), weight);
    }

    protected Agent FindClosest()
    {
        float minDist = float.MaxValue;
        Agent closest = this;

        for (int i = 0; i < _agentManager.Agents.Count; i++)
        {
            if (_agentManager.Agents[i] == this) continue;

            float dist = Vector2.Distance(transform.position, _agentManager.Agents[i].transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                closest = _agentManager.Agents[i];
            }            
        }
        return closest;
    }

    protected Vector3 StayInBounds(float secInAdvance = 1, float weight = 1)
    {
        Vector3 futurePos = GetFuturePosition(secInAdvance);

        if (futurePos.x <= CollisionManager.ScreenMin.x ||
            futurePos.x >= CollisionManager.ScreenMax.x ||
            futurePos.y <= CollisionManager.ScreenMin.y ||
            futurePos.y >= CollisionManager.ScreenMax.y)
        {
            return Seek(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z), weight);
        }
        return Vector3.zero;
    }

    protected Vector3 GetFuturePosition(float secInAdvance = 1)
    {
        return transform.position + (_physicsObject.Velocity * secInAdvance);
    }
}
