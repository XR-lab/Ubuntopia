using UnityEngine;

/// <summary>
/// This Script needs to be removed once the timer is officially linked to the right thing
/// </summary>
public class TimerTester : MonoBehaviour
{
    private Timer timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            timer.StartTimer();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            timer.EndTimer();
            Debug.Log(timer.TotalTime);
        }
    }
}
