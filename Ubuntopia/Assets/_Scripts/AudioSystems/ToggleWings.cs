using System;
using UnityEngine;

public class ToggleWings : MonoBehaviour {
    [SerializeField, Tooltip("Drag manual flying wings here (from scene hierarchy).")]
    private GameObject obj1;

    [SerializeField, Tooltip("Drag automatic flying wings here (from scene hierarchy).")]
    private GameObject obj2;

    [SerializeField, Tooltip("Manual fly animation yes/no.")]
    private bool manual = false;

    private void Start() {
        ToggleObject(manual);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            Toggle();
            ToggleObject(manual);
        }
    }

    public void Toggle() {
        manual = !manual;
    }

    private void ToggleObject(bool b) {
        obj1.SetActive(b);
        obj2.SetActive(!b);
    }
}
