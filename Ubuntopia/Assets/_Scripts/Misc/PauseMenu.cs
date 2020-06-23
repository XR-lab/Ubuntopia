using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool _active = false;
    [SerializeField] private GameObject _player;
    
    public List<GameObject> pauseObjects;
    public int offset;

    private void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two) && !_active|| Input.GetKeyDown(KeyCode.A))
            ActivePause();
        else if(OVRInput.GetDown(OVRInput.Button.Two) && _active)
            DeactivePause();
        
    }

    public void ActivePause()
    {
        Time.timeScale = 0;
        for (int i = 0; i < pauseObjects.Count; i++)
        {
            var obj = pauseObjects[i];
            obj.transform.position = _player.transform.position + _player.transform.forward * offset;
            obj.transform.rotation = Quaternion.Euler(obj.transform.eulerAngles.x, _player.transform.eulerAngles.y, obj.transform.eulerAngles.z); //= new Quaternion(obj.transform.rotation.x, _player.transform.rotation.y, obj.transform.rotation.z, 1);
            obj.SetActive(true);
        }

        _active = true;
    }

    public void DeactivePause()
    {
        Time.timeScale = 1;
        for (int i = 0; i < pauseObjects.Count; i++)
        {
            pauseObjects[i].SetActive(false);
        }

        _active = false;
    }
}
