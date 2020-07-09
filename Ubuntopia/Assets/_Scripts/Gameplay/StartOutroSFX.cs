using System.Collections;
using UnityEngine;

public class StartOutroSFX : MonoBehaviour {
    // References.
    [SerializeField, Header("Drag SFX here (from scene hierarchy).")]
    private SFX_OutroBalla _sfx;
    
    private void Start() {
        // When entering OutroScene, start outro sfx.
        _sfx.PlaySFX();

        // Wait until the end of the frame, then stop ambient music.
        StartCoroutine(StopAmbient());
    }

    private IEnumerator StopAmbient() {
        yield return new WaitForEndOfFrame();
        AudioManager.instance.Stop("AmbientMusic0");
        AudioManager.instance.Stop("AmbientMusic1");
    }
}
