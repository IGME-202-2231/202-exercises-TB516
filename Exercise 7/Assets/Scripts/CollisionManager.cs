using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public static Vector2 ScreenMax
    {
        get
        {
            return new(
                Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect,
                Camera.main.transform.position.y + Camera.main.orthographicSize
                );
        }
    }
    public static Vector2 ScreenMin
    {
        get
        {
            return new(
                Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect,
                Camera.main.transform.position.y - Camera.main.orthographicSize
                );
        }
    }

    /// <summary>
    /// Dictionary containing pairs of a fleer (key) and its seekers (values)
    /// </summary>
    [SerializeField] private SerializedDictionary<CircleCollider, List<CircleCollider>> _colliders = new();

    void Update()
    {
        foreach (KeyValuePair<CircleCollider, List<CircleCollider>> pair in _colliders)
        {
            for (int i = 0; i < pair.Value.Count; i++)
            {
                if (pair.Key.IsCollidingWith(pair.Value[i]))
                {
                    Teleport(pair.Key);
                }
            }
        }
    }

    void Teleport(CircleCollider collider)
    {
        collider.transform.position = new(Random.Range((ScreenMin.x + collider.Radius), (ScreenMax.x - collider.Radius)), Random.Range((ScreenMin.y - collider.Radius), (ScreenMax.y + collider.Radius)));
    }
}
