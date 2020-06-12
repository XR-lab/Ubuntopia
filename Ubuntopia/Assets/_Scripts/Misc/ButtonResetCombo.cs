using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonResetCombo : MonoBehaviour
{
    private float _time;
    private bool _active1, _active2, _active3;

    public float maxTime;
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RHand) && !_active1)
            StartCoroutine(Reseter());
    }

    private IEnumerator Reseter()
    {
        _active1 = true;
        _time = 0;
        while (_time <= maxTime)
        {
            _time += Time.deltaTime;
            if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RHand)&& !_active3 && !_active2)
                _active2 = true;

            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RHand) && _active2 && !_active3)
                _active3 = true;

            if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RHand) && _active2 && _active3)
                SceneManager.LoadScene(0);

            yield return null;
        }
    }
}
