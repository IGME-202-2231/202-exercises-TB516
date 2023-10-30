using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    [SerializeField] List<PhysicsObject> _physicsObjects;

    Vector2 _mousePos;

    void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        for (int i = 0; i < _physicsObjects.Count; i++)
        {
            _physicsObjects[i].ApplyForce((_mousePos - (Vector2)_physicsObjects[i].transform.position) * 4);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(Vector3.zero, _mousePos);
    }
}
