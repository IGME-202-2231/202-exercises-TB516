using UnityEngine;

public enum TagStates
{
    NotIt,
    Counting,
    It
}

public class TagPlayer : Agent
{
    [SerializeField][Range(0f, 100f)] private float _boundsWeight = 10;

    TagStates _curState;
    float _timer = 0;
    TagPlayer _target;

    private void Start()
    {
        _agentManager = FindAnyObjectByType<AgentManager>();
        base.Start();
    }

    protected override void CalcSteeringForces()
    {
        _totalForce += StayInBounds(1, _boundsWeight);

        switch (_curState)
        {
            case TagStates.NotIt:
                _totalForce += Wander();
                break;

            case TagStates.Counting:
                _timer += Time.deltaTime;
                Debug.Log(_timer + " out of " + _agentManager.CountTime);

                if (_timer >= _agentManager.CountTime)
                {
                    _timer = 0;
                    SetState(TagStates.It);
                }

                break;
            case TagStates.It:
                _target = FindClosest() as TagPlayer;

                _totalForce += Seek(_target.transform.position);

                break;
        }
    }

    public void SetState(TagStates newState)
    {
        _curState = newState;

        if (_curState == TagStates.Counting)
        {
            _physicsObject.StopMoving();
            _renderer.sprite = _agentManager.Sprites[0];
        }
        else if (_curState == TagStates.It)
        {
            _renderer.sprite = _agentManager.Sprites[1];
        }
        else
        {
            _renderer.sprite = _agentManager.Sprites[2];
        }
    }
}
