using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private ControllerInput _controllerInput;

    public bool fuck = false;
    void Start()
    {
        if(fuck)StartCoroutine(Timer());
        if (_controllerInput == null) return;
        _controllerInput.nextPhase += SwitchScenes;
    }

    public void SwitchScenes()
    {
        SceneManager.LoadScene(sceneName);
    }

    public AsyncOperation LoadAsync()
    {
        return SceneManager.LoadSceneAsync(sceneName);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(600);
        SwitchScenes();
    }
}
