using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Mounting : MonoBehaviour {
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Transform mountPosition;
    private enum PlayerStatus { Grounded, Mounted, Flying }
    private PlayerStatus status;
    public Action PlayerHasMounted;


    private void Start() {
        status = PlayerStatus.Grounded;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            MountUp();
        }
    }

    private void MountUp() {
        Destroy(playerObject.GetComponent<Rigidbody>());
        playerObject.transform.position = mountPosition.position;
        playerObject.transform.SetParent(mountPosition);

        status = PlayerStatus.Mounted;
        PlayerHasMounted.Invoke();
        print("Announced PlayerHasMounted");
    }
}
