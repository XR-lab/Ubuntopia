using System.Collections;
using UnityEngine;

public class StartOutroSFX : MonoBehaviour {
    // References.
    [SerializeField, Header("Drag AudioManager here (from scene hierarchy).")]
    private SFX_OutroBalla _sfx;
    
    // References.
    [SerializeField, Header("Drag AudioManager here (from scene hierarchy).")]
    private AudioManager _audioManager;

    private void Start() {
        // When entering OutroScene, start outro sfx.
        _sfx.PlaySFX();

        // Wait until the end of the frame, then stop ambient music.
        StartCoroutine(StopAmbient());
    }

    private IEnumerator StopAmbient() {
        yield return new WaitForEndOfFrame();
        _audioManager.Stop("AmbientMusic0");
        _audioManager.Stop("AmbientMusic1");
    }
}
