using UnityEngine;

public class Timer : MonoBehaviour
{
    private float startTime;
    private float endTime;
    private float totalTime;
    
    private float endSeconds;
    private float endMinutes;

    // Either this script has to not destroy on load if going to a other scene or you need to give this value to a don't destroy script
    public float TotalTime { get { return totalTime; } }
    public float EndSeconds { get { return endSeconds; } }
    public float EndMinutes { get { return endMinutes; } }

    public void StartTimer()
    {
        DontDestroyOnLoad(gameObject);
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

    private void FormatTime()
    {
        
    }
}
