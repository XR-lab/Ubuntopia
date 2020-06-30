using System;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField, Tooltip("Drag Harish here.")]
    private GameObject player;
    // [Tooltip("Drag Rotating here.")]
    // [SerializeField] private GameObject playerRot;
    [SerializeField, Tooltip("Drag first waypoint here.")] 
    private GameObject currentTarget;
    private int currentTargetIndex;
    
    // Gameplay values.
    private bool isMoving = true;
    private bool isFlying = false;
    private float arrivalDistance = 1f;
    private float rotationSpeed = 1f;
    
    // Player values.
    private Vector3 currentVelocity;
    private Vector3 currentPosition;
    private Vector3 currentTargetPosition;
    [SerializeField, Tooltip("Enter maximum fly speed for Harish here.")] 
    private float maxSpeed = 20f;
    [SerializeField, Tooltip("How fast can we steer towards new waypoint?")]
    private float mass = 10f;
    
    // Action.
    public Action<int> Arrived;

    private void Start() {
        // Initialize variables.
        currentTargetIndex = 0;
        currentVelocity = new Vector3(0, 0, 0);
    }

    private void FixedUpdate() {
        if (isMoving) {
            Move();
        }
    }

    public void SetTarget(GameObject obj) {
        currentTarget = obj;
        currentTargetPosition = currentTarget.transform.position;
        currentTargetIndex++;
    }

    private void Move() {
        // Distance to target.
        var desiredStep = currentTargetPosition- currentPosition;
        desiredStep.Normalize();
        
        // Calculate speed.
        var desiredVelocity = desiredStep * maxSpeed;
        
        // Calculate steer force.
        var steeringForce = desiredVelocity - currentVelocity;
        currentVelocity += steeringForce / mass;

        // Move player.
        currentPosition += currentVelocity * Time.deltaTime;
        transform.position = currentPosition;

        // Look towards.
        Quaternion lookAt = Quaternion.LookRotation(desiredStep);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookAt, Time.deltaTime * rotationSpeed);

        // Tilt sideways (doesn't work yet).
        // TiltObject(player, playerRot, currentTargetPosition);

        // Announce we have reached target, get new target.
        if (Vector3.Distance(currentTarget.transform.position, currentPosition) < arrivalDistance) {
            Arrived.Invoke(currentTargetIndex);
        }
    }

    private void TiltObject(GameObject parent, GameObject obj, Vector3 target) {
        Vector3 dir = target - obj.transform.position;
        float direction = AngleDir(Vector3.forward, dir, Vector3.up);
        Vector3 rotation = new Vector3(0, 0, 15);

        // Test.
        if (direction < 0) {
            obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, Quaternion.Euler(rotation), Time.deltaTime * rotationSpeed);
        } else {
            obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, Quaternion.Euler(-rotation), Time.deltaTime * rotationSpeed);
        }
    }
    
    // Returns -1 when to the left, 1 to the right, and 0 for forward/backward
    public float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);
 
        if (dir > 0.0f) {
            return 1.0f;
        } else if (dir < 0.0f) {
            return -1.0f;
        } else {
            return 0.0f;
        }
    }

    public void SetActive(bool state)
    {
        isMoving = state;
        currentPosition = player.transform.position;
        currentTargetPosition = currentTarget.transform.position;
    }

    public float GetMaxSpeed()
    {
        return maxSpeed;
    }
    
    
    // Look towards (works).
    // transform.LookAt(currentTargetPosition);
        
    // Vector3 newDirection = Vector3.RotateTowards(
    //     player.transform.forward, 
    //     desiredStep, 
    //     0.01f, 
    //     0f);
    // transform.rotation = Quaternion.LookRotation(newDirection);
    
    // Look towards (works).
    // Vector3 newDirection = Vector3.RotateTowards(
    //     player.transform.forward, 
    //     desiredStep, 
    //     0.01f, 
    //     0f);
    // transform.rotation = Quaternion.LookRotation(newDirection);

    public GameObject GetTarget()
    {
        return currentTarget;
    }
}
