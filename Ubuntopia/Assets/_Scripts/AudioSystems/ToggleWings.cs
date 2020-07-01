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

    public void Toggle() {
        manual = !manual;
        ToggleObject(manual);
    }

    private void ToggleObject(bool b) {
        obj1.SetActive(b);
        obj2.SetActive(!b);
    }
}
