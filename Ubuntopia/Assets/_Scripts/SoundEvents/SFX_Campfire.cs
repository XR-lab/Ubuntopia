using System;
using UnityEngine;

public class SFX_Campfire : MonoBehaviour {
    private string name = "Campfire";
    
    // References.
    [SerializeField, Header("Drag AudioManager here (from scene hierarchy).")]
    private AudioManager _audioManager;

    private void Start() {
        PlaySFX();
    }

    private void PlaySFX() {
        _audioManager.Play(name);
    }
}
