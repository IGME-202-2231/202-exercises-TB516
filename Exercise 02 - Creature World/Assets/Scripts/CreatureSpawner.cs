using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _creaturePrefab;

    [SerializeField]
    private Vector3[] _spawnPositionArray = new Vector3[3];

    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _spawnPositionArray.Length; i++) Instantiate(_creaturePrefab, _spawnPositionArray[i], Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
