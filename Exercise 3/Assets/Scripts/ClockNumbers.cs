using System.Diagnostics;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    [SerializeField]
    private TextMesh _numberPrefab;

    //Debug stopwatch to track time
    private Stopwatch _stopwatch = new();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            TextMesh number = Instantiate(_numberPrefab);
            number.text = (i + 1).ToString();

            number.transform.position = new(Mathf.Sin((Mathf.PI / 6) + ((Mathf.PI / 6) * i)) * 2.25f, Mathf.Cos((Mathf.PI / 6) + ((Mathf.PI / 6) * i)) * 2.25f, 0);
        }

        _stopwatch.Start();
    }

    private void OnGUI()
    {
        GUI.Label(new(50, 50, 50, 50), (_stopwatch.Elapsed.Seconds % 60).ToString());
    }
}
