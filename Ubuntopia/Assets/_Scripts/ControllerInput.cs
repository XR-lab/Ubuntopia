using System.Collections;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private OVRInput.Button holdbutton;

    private bool _startIenumerator = true;
    private float currentTime = 0f;
    public delegate void nextPhaseStarter();
    public nextPhaseStarter nextPhase;

    void Update()
    {
        if (currentTime < maxTime)
        {
            ButtonCheck(holdbutton);
        }
        else if (_startIenumerator)
        {
            _startIenumerator = false;
            StartCoroutine(Intro());
        }
    }

    private IEnumerator Intro()
    {
        string clipName = "Intro";
        AudioManager am = AudioManager.instance;
        float waitTimer = am.GetClipData(clipName).clip.length;
        am.Play(clipName);
        
        yield return new WaitForSeconds(waitTimer);

        nextPhase();
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
