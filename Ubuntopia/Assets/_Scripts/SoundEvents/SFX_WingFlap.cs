using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_WingFlap : MonoBehaviour {
    [SerializeField, Tooltip("Drag AudioManager here (from scene).")]
    private AudioManager _audioManager;

    public void PlayWingFlap() {
        print("Playing wing flap sound.");
        _audioManager.Play("Wings");
    }
}
