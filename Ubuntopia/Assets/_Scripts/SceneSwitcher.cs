using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void SwitchScenes()
    {
        SceneManager.LoadScene(sceneName);
    }

    public AsyncOperation LoadAsync()
    {
        return SceneManager.LoadSceneAsync(sceneName);
    }
}
