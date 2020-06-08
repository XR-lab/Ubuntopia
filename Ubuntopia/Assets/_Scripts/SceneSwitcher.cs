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
        _controllerInput.nextPhase += SwitchScenes;
    }

    private void SwitchScenes()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
