using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private OVRInput.Button holdbutton;

    private float currentTime = 0f;
    public delegate void nextPhaseStarter();
    public nextPhaseStarter nextPhase;

    void Update()
    {
        if (currentTime < maxTime)
        {
            ButtonCheck(holdbutton);
        }
        else
        {
            nextPhase();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextPhase();
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
