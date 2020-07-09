using UnityEngine;
using Random = UnityEngine.Random;

public class SFX_Wind : MonoBehaviour {
    // This script creates our own loop to randomize when the sfx is played.
    // Make sure the sfx "loop" option is unticked.
    [SerializeField, Tooltip("Enter the min range for random time.")]
    private float minTime = 3f;

    [SerializeField, Tooltip("Enter the max range for random time.")]
    private float maxTime = 5f;

    [SerializeField, Tooltip("Enter how many sfx variations you have.")]
    private int numberOfVariations;

    private float randomTime;
    private float timer;
    public bool isMoving = false;
    
    // Default string name for sfx file.
    private string name = "Wind";
    
    // References.
    [SerializeField, Tooltip("Drag AudioManager here (from scene).")]
    private AudioManager _audioManager;

    private void Start() {
        // Initialize randomtime.
        randomTime = Random.Range(minTime, maxTime);
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

    public void PlaySFX() {
        AudioManager.instance.PlayRandom(name, numberOfVariations);
        randomTime = Random.Range(minTime, maxTime);
    }
}