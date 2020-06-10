using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedExit : MonoBehaviour
{
    private float _begin = 0;

    public float maxTime;
    
    void Update()
    {
        _begin += Time.deltaTime;
        if (_begin >= maxTime)
        {
            SceneManager.LoadScene(0);
            Debug.Log("Exit");
        }
    }
}
