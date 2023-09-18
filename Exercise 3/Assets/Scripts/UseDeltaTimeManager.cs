using UnityEngine;

public class UseDeltaTimeManager : MonoBehaviour
{
    /// <summary>
    /// Bool to determine weather to use delta time in the rotate clock hand script
    /// </summary>
    private static bool s_useDeltaTime = true;

    /// <summary>
    /// Bool to determine weather to use delta time in the rotate clock hand script
    /// </summary>
    public static bool UseDeltaTime => s_useDeltaTime;

    [SerializeField]
    private bool _useDeltaTime = true;

    // Update is called once per frame
    void Update()
    {
        s_useDeltaTime = _useDeltaTime;
    }
}
