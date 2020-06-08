using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualLogger : MonoBehaviour
{
    [SerializeField] private ControllerInput _controllerInput;
    [SerializeField] private Text debugText;
    
    void Start()
    {
        _controllerInput.nextPhase += TestMessage;
    }

    void Update()
    {
        
    }

    private void TestMessage()
    {
        debugText.text = "This works";
    }
}
