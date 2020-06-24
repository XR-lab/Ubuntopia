using System;
using UnityEngine;

public class Waypoints : MonoBehaviour {
    [Tooltip("Drag waypoints here in correct order.")]
    [SerializeField] private GameObject[] waypoints;
    
    // Action.
    public Action<GameObject> Arrived;
    
    // References.
    [Tooltip("Drag Harish here.")]
    [SerializeField] private Movement _movement;

    private void Start() {
        _movement.Arrived += SetNewTarget;
    }

    private void SetNewTarget(int old) {
        // Announce we arrived at this waypoint object.
        Arrived.Invoke(waypoints[old]);
        
        // Find the next waypoint in the array.
        GameObject newTarget = waypoints[(old + 1) % waypoints.Length];
        
        // Set new target.
        _movement.SetTarget(newTarget);
    }
}
