using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [Tooltip("Drag Harish here.")]
    [SerializeField] private GameObject player;
    
    [SerializeField] private GameObject currentTarget;
    [SerializeField] private int currentTargetIndex;
    
    // Gameplay values.
    [SerializeField] private bool isMoving = true;
    private bool isFlying = false;
    private float arrivalDistance = 1f;
    
    // Player values.
    [SerializeField] private Vector3 currentVelocity;
    [SerializeField] private Vector3 currentPosition;
    [Tooltip("Maximum speed?")]
    [SerializeField] private float maxSpeed = 20f;
    [Tooltip("How fast can we steer towards new waypoint?")]
    [SerializeField] private float mass = 20f;

    //public Transform pointer;
    
    // Action.
    public Action<int> Arrived;

    private void Start() {
        currentTargetIndex = 0;
        currentVelocity = new Vector3(0, 0, 0);
        currentPosition = player.transform.position;
    }

    private void Update() {
        if (isMoving) {
            Move();
        }
    }

    public void SetTarget(GameObject obj) {
        print("SetTarget called.");
        currentTarget = obj;
        currentTargetIndex++;
    }

    private void Move() {
        // Distance to target.
        var desiredStep = currentTarget.transform.position - currentPosition;
        desiredStep.Normalize();
        
        // Calculate speed.
        var desiredVelocity = desiredStep * maxSpeed;
        
        // Calculate steer force.
        var steeringForce = desiredVelocity - currentVelocity;
        currentVelocity += steeringForce / mass;

        // Move player.
        currentPosition += currentVelocity * Time.deltaTime;
        transform.position = currentPosition;
        
        // Rotate towards.
        Quaternion lookAt = Quaternion.LookRotation(desiredStep);
        // Check if target is to the left/right.
        // {...}
        // Vector3 zAxis = Vector3.RotateTowards(
        //     player.transform.up,
        //     desiredStep,
        //     -1f,
        //     0f);
        // lookAt.z = zAxis.z;
        transform.rotation = Quaternion.Lerp(transform.rotation, lookAt, Time.deltaTime * 1f);
        

        // Announce we have reached target, get new target.
        if (Vector3.Distance(currentTarget.transform.position, currentPosition) < arrivalDistance) {
            Arrived.Invoke(currentTargetIndex);
        }
    }

    private bool IsTargetLeft(Vector3 obj, Vector3 target) {
        return true;
    }
    
    // Works.
    // Vector3 newDirection = Vector3.RotateTowards(
    //     player.transform.forward, 
    //     desiredStep, 
    //     0.01f, 
    //     0f);
    // transform.rotation = Quaternion.LookRotation(newDirection);
}
