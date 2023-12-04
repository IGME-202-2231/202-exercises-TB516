using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    [SerializeField] Agent _agentPrefab;
    [SerializeField] uint _agentCount;
    [SerializeField] private float _time = 2;
    [SerializeField] Sprite[] _tagSprites;

    List<Agent> _agents;

    public List<Agent> Agents => _agents;

    public float CountTime
    {
        get => _time;
    }
    public Sprite[] Sprites
    {
        get
        {
            return _tagSprites;
        }
    }

    void Start()
    {
        _agents = new();
        for (int i = 0; i < _agentCount; i++)
        {
            SpawnAgent();
        }

        /*(_agents[0] as TagPlayer).SetState(TagStates.Counting);*/
    }
    void SpawnAgent()
    {
        Agent agent = Instantiate(_agentPrefab);
        agent.Manager = this;

        _agents.Add(agent);
        FlockManager.Instance.AddToFlock(agent);
    }
}
