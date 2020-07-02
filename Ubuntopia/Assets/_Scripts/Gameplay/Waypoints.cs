using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waypoints : MonoBehaviour {
    [SerializeField, Tooltip("Drag waypoints parent GameObject here")]
    private GameObject waypointParent;
    private List<GameObject> waypoints = new List<GameObject>();

    // Action.
    public Action<GameObject> Arrived;
    public Action LastWaypoint;

    // References.
    [Tooltip("Drag Harish here.")] [SerializeField]
    private Movement _movement;

    public void ForcedStart() {
        InitializeWaypointList();
        
        // Subscribe to event.
        _movement.Arrived += SetNewTarget;
    }

    private void OnDestroy() {
        // Unsubscribe from event.
        _movement.Arrived -= SetNewTarget;
    }

    private void InitializeWaypointList() {
        foreach (Transform obj in waypointParent.transform) {
            waypoints.Add(obj.gameObject);
        }
    }

    private void SetNewTarget(int old) {
        // Announce we arrived at this waypoint object.
        Arrived.Invoke(waypoints[old]);

        // Find the next waypoint in the array.
        if (waypoints[(old + 1)] != null) {
            GameObject newTarget = waypoints[(old + 1)];
            
            // Set new target.
            _movement.SetTarget(newTarget);
            
            // Stop rest of the function.
            return;
        }
        
        // If code reaches this part, we have reached second to last waypoint. Announce it.
        LastWaypoint.Invoke();
        SceneManager.LoadScene("EndScreen");
    }

    public GameObject GetFirstWaypoint() {
        return waypoints[0];
    }
}
