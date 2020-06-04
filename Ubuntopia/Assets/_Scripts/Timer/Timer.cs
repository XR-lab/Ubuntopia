using UnityEngine;

public class Timer : MonoBehaviour
{
    private float startTime;
    private float endTime;
    private float totalTime;

    // Either this script has to not destroy on load if going to a other scene or you need to give this value to a don't destroy script
    public float TotalTime { get { return totalTime; } }

    public void StartTimer()
    {
        startTime = Time.time;
    }

    public void EndTimer()
    {
        endTime = Time.time;
        CalculateTotalTime();
    }

    private void CalculateTotalTime()
    {
        totalTime = endTime - startTime;
    }
}
