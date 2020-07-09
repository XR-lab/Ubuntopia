using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonResetCombo : MonoBehaviour
{
    private float _time;
    private bool _active1, _active2, _active3;
    private bool _timing;
    
    public OVRInput.Controller controller;
    public float maxTime;
    public int targetScene;
    
    void Update()
    {
        OVRInput.Update();
        if (_timing)
            _time += Time.deltaTime;

        if (OVRInput.Get(OVRInput.RawButton.A, controller) && !_active1 && _time <= maxTime)
        {
            _active1 = true;
            _timing = true;
        }
        
        if (OVRInput.Get(OVRInput.RawButton.B, controller) && _active1 && !_active3 && !_active2&& _time <= maxTime)
            _active2 = true;

        if (OVRInput.Get(OVRInput.RawButton.A, controller) && _active2 && !_active3 && _time <= maxTime)
            _active3 = true;

        if (OVRInput.Get(OVRInput.RawButton.A, controller) && _active2 && _active3 && _time <= maxTime) 
            SceneManager.LoadScene(targetScene);
        
        if (_time > maxTime)
        {
            _timing = false;
            _active1 = false; 
            _active2 = false; 
            _active3 = false;
        }
    }
}
