using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo2Script : MonoBehaviour
{
    [SerializeField]
    string _creatureName;
    [SerializeField]
    int _health;

    [SerializeField]
    GameObject _creaturePrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(_creaturePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
