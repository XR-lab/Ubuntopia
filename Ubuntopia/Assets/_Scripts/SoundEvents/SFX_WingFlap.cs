using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_WingFlap : MonoBehaviour {
    [SerializeField, Tooltip("Drag Audiomanager here.")]
    private AudioManager _audioManager;

    public void PlayWingFlap() {
        print("playing wing flap");
        _audioManager.Play("WingFlap_Test");
    }
}
