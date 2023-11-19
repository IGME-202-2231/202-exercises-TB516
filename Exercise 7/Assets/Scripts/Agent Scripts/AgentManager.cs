using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    [SerializeField] Agent _agentPrefab;
    [SerializeField] uint _playerCount;
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
        for (int i = 0; i < _playerCount; i++)
        {
            SpawnPlayer();
        }
        (_agents[0] as TagPlayer).SetState(TagStates.Counting);
    }
    void SpawnPlayer()
    {
        _agents.Add(Instantiate(_agentPrefab));
    }
}
