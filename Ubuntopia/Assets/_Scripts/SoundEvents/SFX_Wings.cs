using UnityEngine;

public class SFX_Wings : MonoBehaviour {
    // Default string name for sfx file.
    private string name = "Wings_Single";

    // References.
    [SerializeField, Tooltip("Drag AudioManager here (from scene).")]
    private AudioManager _audioManager;
    
    public void PlaySFX() {
        _audioManager.Play(name);
    }
}
