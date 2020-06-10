using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    [SerializeField] private ControllerInput _controllerInput;

    void Start()
    {
        if (_controllerInput == null) return;
        _controllerInput.nextPhase += SwitchScenes;
    }

    public void SwitchScenes()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public AsyncOperation LoadAsync()
    {
        return SceneManager.LoadSceneAsync(sceneIndex);
    }
}
