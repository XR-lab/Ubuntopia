using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool _active = false;
    
    public List<GameObject> pauseObjects;

    private void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One) && !_active)
            ActivePause();
        else
            DeactivePause();
        
    }

    public void ActivePause()
    {
        Time.timeScale = 0;
        for (int i = 0; i < pauseObjects.Count; i++)
        {
            pauseObjects[i].SetActive(true);
        }
    }

    public void DeactivePause()
    {
        Time.timeScale = 1;
        for (int i = 0; i < pauseObjects.Count; i++)
        {
            pauseObjects[i].SetActive(false);
        }
    }
}
