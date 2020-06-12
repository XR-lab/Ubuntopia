using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private SceneSwitcher _sceneSwitcher;
    
    void Start()
    {
        StartCoroutine(LoadAsyncScene());
    }
    
    private IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncScene = _sceneSwitcher.LoadAsync();
        asyncScene.allowSceneActivation = false;
        _videoPlayer.Play();
        bool playing = false;
        yield return new WaitForSeconds((float)_videoPlayer.clip.length);
        asyncScene.allowSceneActivation = true;
    }
}
