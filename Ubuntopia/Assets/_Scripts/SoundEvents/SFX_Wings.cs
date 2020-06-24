using UnityEngine;

public class SFX_Wings : MonoBehaviour {
    // This script creates our own loop to have full control over when to play the fly sfx.
    // Make sure the sfx "loop" option is unticked.
    [SerializeField, Tooltip("Enter the length of the wing flap animation.")]
    private float animationTime = 2f;
    private float timer;
    private bool isMoving = false;
    
    // Default string name for sfx file.
    private string name = "Wings";

    // References.
    [SerializeField, Tooltip("Drag AudioManager here (from scene).")]
    private AudioManager _audioManager;
    [SerializeField, Tooltip("Drag Harish here (from scene).")]
    private Movement _movement;

    private void Start() {
        // Subscribe to event.
        _movement.Moving += StartPlaying;
        
        // Play sfx on start.
        PlaySFX();
    }

    private void OnDestroy() {
        // Unsubscribe to prevent bugs on restart.
        _movement.Moving -= StartPlaying;
    }

    private void Update() {
        if (isMoving) {
            if (timer >= animationTime) {
                PlaySFX();
                timer = 0;
            }
            timer += Time.deltaTime;
        }
    }
    
    private void StartPlaying() {
        isMoving = true;
    }

    public void PlaySFX() {
        _audioManager.Play(name);
    }
}
