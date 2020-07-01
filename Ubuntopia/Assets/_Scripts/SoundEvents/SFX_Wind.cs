using UnityEngine;
using Random = UnityEngine.Random;

public class SFX_Wind : MonoBehaviour {
    // This script creates our own loop to randomize when the sfx is played.
    // Make sure the sfx "loop" option is unticked.
    [SerializeField, Tooltip("Enter the min time the sfx can occur.")]
    private float minTime = 3f;

    [SerializeField, Tooltip("Enter the max time the sfx can occur.")]
    private float maxTime = 5f;

    [SerializeField, Tooltip("Enter how many sfx variations you have.")]
    private int numberOfVariations;

    private float randomTime;
    private float timer;
    private bool isMoving = false;
    
    // Default string name for sfx file.
    private string name = "Wind";
    
    // References.
    [SerializeField, Tooltip("Drag AudioManager here (from scene).")]
    private AudioManager _audioManager;
    [SerializeField, Tooltip("Drag Harish here (from scene).")]
    private Movement _movement;

    private void Start() {
        // Subscribe to event.
        _movement.Moving += StartPlaying;
        
        // Initialize randomtime.
        randomTime = Random.Range(minTime, maxTime);
    }
    
    private void OnDestroy() {
        // Unsubscribe to prevent bugs on restart.
        _movement.Moving -= StartPlaying;
    }

    private void Update() {
        if (isMoving) {
            if (timer >= randomTime) {
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
        _audioManager.PlayRandom(name, numberOfVariations);
        randomTime = Random.Range(minTime, maxTime);
    }
    
}