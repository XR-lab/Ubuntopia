using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFlight : MonoBehaviour { 
    private GameObject harishObject;
    private Rigidbody harishRb;
    [SerializeField] private Mounting _mounting;
    [SerializeField] private float movementSpeed = 3f;
    private float waitTime = 3f;
    private float waitTimer = 0f;
    private bool isFlying = false;

    private void Start() {
        harishObject = gameObject;
        harishRb = harishObject.GetComponent<Rigidbody>();
        _mounting.PlayerHasMounted += StartFlight;
    }

    private void Update() {
        if (isFlying) {
            StartFlight();
        }
    }

    private void StartFlight() {
        if (!isFlying) {
            isFlying = true;
        }

        if (waitTimer < waitTime) {
            waitTimer += Time.deltaTime;
        } else { 
            harishRb.velocity = (Vector3.forward * movementSpeed);
        }
    }
}
