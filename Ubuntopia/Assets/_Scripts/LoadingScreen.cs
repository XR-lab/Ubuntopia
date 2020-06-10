using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private SceneSwitcher _sceneSwitcher;
    [SerializeField] private VisualLogger _logger;
    
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
        
        while (!asyncScene.isDone)
        {
            if (!_videoPlayer.isPlaying && playing)
            {
                asyncScene.allowSceneActivation = true;
            }
            else if (_videoPlayer.isPlaying)
            {
                playing = true;
            }

            _logger.TestMessage("Progress: " + asyncScene.progress + ", video playing: " + _videoPlayer.isPlaying + ", playing: " + playing);
            yield return null;
        }
        _logger.TestMessage("Apples!!! Progress: " + asyncScene.progress + ", video playing: " + _videoPlayer.isPlaying + ", playing: " + playing);
    }
}
