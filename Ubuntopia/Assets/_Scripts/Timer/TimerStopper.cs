using UnityEngine;
using UnityEngine.UI;

public class TimerStopper : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    private Timer _timer;
    
    void Start()
    {
        _timer = FindObjectOfType<Timer>();
        _timer.EndTimer();
        SetTimerText();
        _timer.gameObject.transform.parent = transform;
    }

    private void SetTimerText()
    {
        string time = "You took " + _timer.EndMinutes + " minutes and ";
        int seconds =  _timer.EndSeconds;
        if (seconds < 10)
        {
            time += "0";
        }

        time += seconds + " seconds";
        _timerText.text = time;
    }
}
