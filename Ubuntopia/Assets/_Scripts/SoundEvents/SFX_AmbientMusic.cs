using UnityEngine;
using Random = UnityEngine.Random;

public class SFX_AmbientMusic : MonoBehaviour {
    // Make sure the sfx "loop" option is ticked.
    // Default string name for sfx file.
    private string name = "AmbientMusic";
    
    // References.
    [SerializeField, Tooltip("Drag AudioManager here (from scene).")]
    private AudioManager _audioManager;

    private void Start() {
        // Play both sfx on start.
        PlaySFX();
    }

    public void PlaySFX() {
        _audioManager.Play(name + 0);
        _audioManager.Play(name + 1);
    }
    
}