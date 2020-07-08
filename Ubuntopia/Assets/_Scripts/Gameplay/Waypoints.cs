using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waypoints : MonoBehaviour {
    [SerializeField, Header("Drag __Waypoints here (from scene hierarchy).")]
    private GameObject waypointParent;
    private List<GameObject> waypoints = new List<GameObject>();

    // Action.
    public Action<GameObject> Arrived;
    public Action LastWaypoint;
    
    // Testing purposes.
    private float time = 0;
    [SerializeField, Header("Delay between waypoint check. Default = 1.")]
    private float delay = 1f;

    // References.
    [SerializeField, Header("Drag Harish here (from scene hierarchy).")]
    private Movement _movement;
    [SerializeField, Header("Drag Harish here (from scene hierarchy).")]
    private ToggleWings _toggleWings;

    public void ForcedStart() {
        InitializeWaypointList();
        
        // Subscribe to event.
        _movement.Arrived += SetNewTarget;
        _toggleWings.StartedAutomaticFlight += SetTargetToClosestWaypoint;
    }

    private void Update() {
        time += Time.deltaTime;
        if (time >= delay) {
            Arrived.Invoke(GetClosestWaypoint());
            time = 0;
        }
    }

    private void OnDestroy() {
        // Unsubscribe from event.
        _movement.Arrived -= SetNewTarget;
        _toggleWings.StartedAutomaticFlight -= SetTargetToClosestWaypoint;
    }

    private void InitializeWaypointList() {
        foreach (Transform obj in waypointParent.transform) {
            waypoints.Add(obj.gameObject);
        }
    }

    private void SetNewTarget(GameObject oldObj) {
        // Find same waypoint in our list.
        for (int i = 0; i < waypoints.Count; i++) {
            if (oldObj == waypoints[i]) {
                // Set variable to match.
                // GameObject oldTarget = waypoints[i];
                // Announce we arrived at this waypoint object.
                // Arrived.Invoke(oldTarget);
                
                if (waypoints[(i + 1)] != null) {
                    GameObject newTarget = waypoints[(i + 1)];
            
                    // Set new target.
                    _movement.SetTarget(newTarget);
            
                    // Stop rest of the function.
                    return;
                }
            }
        }
        
        // If code reaches this part, we have reached second to last waypoint. Announce it.
        LastWaypoint.Invoke();
        // SceneManager.LoadScene("OutroScene");
    }

    /// <summary>
    /// This function checks distance between player and waypoints.
    /// If it returns a waypoint, that waypoint distance will be the minimal distance.
    /// It does so until it ends up with the closest one, and returns it.
    /// </summary>
    /// <returns></returns>
    private GameObject GetClosestWaypoint() {
        GameObject player = _movement.gameObject;
        GameObject closestWaypoint = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject w in waypoints) {
            Vector3 distance = player.transform.position - w.transform.position;
            float sqrLen = distance.sqrMagnitude;

            if (sqrLen < minDistance) {
                // Set closest waypoint to the waypoint found.
                closestWaypoint = w;
                // Adjust minimum distance.
                minDistance = sqrLen;
            }
        }

        return closestWaypoint;
    }

    // This function places the player back on the rail.
    private void SetTargetToClosestWaypoint() {
        GameObject newWaypoint = null;
        GameObject closestWaypoint = GetClosestWaypoint();
        for (int i = 0; i < waypoints.Count; i++) {
            if (waypoints[i] == closestWaypoint) {
                if (waypoints[i + 1] != null) {
                    // Set new waypoint plus one. (We do not want to fly backwards).
                    newWaypoint = waypoints[i + 1];
                    // Assign target.
                    _movement.SetTarget(newWaypoint);
                    return;
                } else {
                    // If plus one does not exist, set to the closest one.
                    newWaypoint = waypoints[i];
                    _movement.SetTarget(newWaypoint);
                }
                
                print("No waypoint found.");
            }
        }
    }

    public GameObject GetFirstWaypoint() {
        return waypoints[0];
    }
}
