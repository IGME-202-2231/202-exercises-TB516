using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private List<SpriteInfo> _collidables;

    // Start is called before the first frame update
    void Start()
    {
        _collidables = new(FindObjectsOfType<SpriteInfo>());
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _collidables.Count; i++)
        {
            _collidables[i].IsColiding = false;
        }

        for (int i = 0; i < _collidables.Count; i++)
        {
            for (int j = i + 1; j < _collidables.Count; j++)
            {
                bool isColiding;

                switch (SpriteInfo.UseCircleColider)
                {
                    case true:
                        isColiding = CircleCollision(_collidables[i], _collidables[j]);
                        break;
                    case false:
                         isColiding = AABBCollision(_collidables[i], _collidables[j]);
                        break;
                }
                

                if (!_collidables[i].IsColiding) _collidables[i].IsColiding = isColiding;
                if (!_collidables[j].IsColiding) _collidables[j].IsColiding = isColiding;
            }
        }
    }

    private bool AABBCollision(SpriteInfo a, SpriteInfo b)
    {
        return b.RectMin.x < a.RectMax.x && b.RectMax.x > a.RectMin.x && b.RectMax.y > a.RectMin.y && b.RectMin.y < a.RectMax.y;
    }
    
    private bool CircleCollision(SpriteInfo a, SpriteInfo b)
    {
        return (a.transform.position - b.transform.position).magnitude < a.Radius + b.Radius;
    }

    private void OnGUI()
    {
        GUI.Label(new(0, 0, 200, 200), $"Space to toggle between bounding boxes.\nCircle bounds active: {SpriteInfo.UseCircleColider}");
    }
}
