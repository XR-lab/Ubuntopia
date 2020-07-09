using System;
using UnityEngine;

public class SFX_OutroBalla : MonoBehaviour {
    // Default string name for sfx.
    private string name = "Outro_Balla_";
    
    public void PlaySFX() {
        AudioManager.instance.PlayLanguage(name);
    }
}
