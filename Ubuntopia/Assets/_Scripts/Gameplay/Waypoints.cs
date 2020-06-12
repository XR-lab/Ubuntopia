using UnityEngine;

public class Waypoints : MonoBehaviour {
    [Tooltip("Drag waypoints here in correct order.")]
    [SerializeField] private GameObject[] waypoints;
    
    // References.
    [Tooltip("Drag Harish here.")]
    [SerializeField] private Movement _movement;

    private void Start() {
        _movement.Arrived += SetNewTarget;
    }

    private void SetNewTarget(int old) {
        GameObject newTarget = waypoints[(old + 1) % waypoints.Length];
        _movement.SetTarget(newTarget);
    }
}
