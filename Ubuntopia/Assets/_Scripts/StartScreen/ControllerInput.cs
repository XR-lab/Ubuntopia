using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private OVRInput.Button holdbutton;
    [SerializeField] private IntroManager _introManager;

    private bool _startIenumerator = true;
    private float currentTime = 0f;

    void Update()
    {
        if (currentTime < maxTime)
        {
            ButtonCheck(holdbutton);
        }
        else if (_startIenumerator)
        {
            _startIenumerator = false;
            _introManager.StartIntro();
        }
    }

    private void ButtonCheck(OVRInput.Button button)
    {
        if (OVRInput.Get(button))
        {
            currentTime += Time.deltaTime;
        } else if (OVRInput.GetUp(button))
        {
            if (currentTime > 0) currentTime -= Time.deltaTime;
            else if (currentTime < 0) currentTime = 0;
        }
    }
}
