using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Mounting : MonoBehaviour {
    [Tooltip("Drag player here.")]
    [SerializeField] private GameObject playerObject;
    [Tooltip("Drag mount position here.")]
    [SerializeField] private Transform mountPosition;
    [Tooltip("Drag mount trigger collider here.")]
    [SerializeField] private Collider mountCol;
    [Tooltip("Drag Canvas>BlackScreen here.")]
    [SerializeField] private Animator blackScreenAnimator;
    [Tooltip("How long is the fade to black duration?")]
    [SerializeField] private float blackScreenFadeOutDuration = 1f;

    private float blackScreenTimer = 0f;
    
    [SerializeField] private bool canMount = false;
    public Action PlayerHasMounted;
    
    // References.
    [Tooltip("Drag player here.")]
    [SerializeField] private PlayerStatus _playerStatus;

    private void Update() {
        // If within mount area..
        if (canMount) {
            // If player is idle or grounded..
            if (_playerStatus.GetStatus() == 0||
                _playerStatus.GetStatus() == 1) {
                if (Input.GetKeyDown(KeyCode.T)) {
                    StartMountUp();
                }
            }
        }
    }

    private void StartMountUp() {
        blackScreenAnimator.SetTrigger("StartFade");
    }

    public void MountUp() {
        // Destroy player rigidbody to avoid player-mount collision.
        Destroy(playerObject.GetComponent<Rigidbody>());
        // Place player on mount.
        playerObject.transform.position = mountPosition.position;
        // Set player as part of the mount.
        playerObject.transform.SetParent(mountPosition);
        PlayerHasMounted.Invoke();
        // Escape loop.
        canMount = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other == mountCol) {
            canMount = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other == mountCol) {
            canMount = false;
        }
    }
}
