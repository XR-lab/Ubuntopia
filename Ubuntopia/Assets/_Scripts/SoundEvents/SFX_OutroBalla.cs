using System;
using UnityEngine;

public class SFX_OutroBalla : MonoBehaviour {
    private string name = "Outro_Balla_";
    
    // References.
    [SerializeField, Header("Drag AudioManager here.")]
    private AudioManager _audioManager;

    private void Start() {
        PlaySFX();
    }

    public void PlaySFX() {
        _audioManager.PlayLanguage(name);
    }
}
