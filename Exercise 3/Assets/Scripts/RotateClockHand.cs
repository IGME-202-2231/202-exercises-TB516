using UnityEngine;

public class RotateClockHand : MonoBehaviour
{
    private static readonly float SecondHandRotateAmount = -(360f / 60);
    private static readonly float MinuteHandRotateAmount = -(360f / 3600);
    private static readonly float HourHandRotateAmount = -(360f / 43200);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (UseDeltaTimeManager.UseDeltaTime)
        {
            switch (gameObject.name)
            {
                case "SecondHand":
                    transform.Rotate(new Vector3(0, 0, SecondHandRotateAmount * Time.deltaTime));
                    break;
                case "MinuteHand":
                    transform.Rotate(new Vector3(0, 0, MinuteHandRotateAmount * Time.deltaTime));
                    break;
                case "HourHand":
                    transform.Rotate(new Vector3(0, 0, HourHandRotateAmount * Time.deltaTime));
                    break;
                default:
                    Debug.Log($"Object {gameObject.name} is not a clock hand!");
                    break;
            }
        }
        else
        {
            switch (gameObject.name)
            {
                case "SecondHand":
                    transform.Rotate(new Vector3(0, 0, SecondHandRotateAmount));
                    break;
                case "MinuteHand":
                    transform.Rotate(new Vector3(0, 0, MinuteHandRotateAmount));
                    break;
                case "HourHand":
                    transform.Rotate(new Vector3(0, 0, HourHandRotateAmount));
                    break;
                default:
                    Debug.Log($"Object {gameObject.name} is not a clock hand!");
                    break;
            }
        }
        
    }
}
