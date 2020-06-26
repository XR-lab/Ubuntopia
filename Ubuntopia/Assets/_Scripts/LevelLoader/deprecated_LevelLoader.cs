using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {
    [SerializeField] private WaypointTileData _data;
    
    [SerializeField, Tooltip("Drag all waypoints here (from the scene hierarchy).")] 
    private List<GameObject> allWaypoints;
    
    [SerializeField, Tooltip("Drag all level tiles here (from the scene hierarchy).")] 
    private List<GameObject> allTiles;

    [SerializeField, Tooltip("Drag Harish here.")]
    private Waypoints _waypoints;

    // For testing purposes, these variables are serialized.
    [SerializeField] private List<GameObject> waypoints;
    [SerializeField] private List<GameObject> tiles;
    [SerializeField] private List<bool> active;

    private void Start() {
        InitializeDictionaries();
        
        // Subscribe to event.
        _waypoints.Arrived += UpdateTiles;
    }

    private void OnDestroy() {
        // Unsubscribe to avoid bugs when restarting games/scene.
        _waypoints.Arrived -= UpdateTiles;
    }

    // Add every waypoints/tiles/booleans to its own list.
    private void InitializeDictionaries() {
        foreach (var obj in _data.waypointTileData) {
            // Loop through all waypoints to match the asset with the gameobject.
            for (int i = 0; i < allWaypoints.Count; i++) {
                if (obj.waypoint.name == allWaypoints[i].name) {
                    waypoints.Add(allWaypoints[i]);
                }
            }
            
            // Loop through all tiles to match the asset with the gameobject.
            for (int i = 0; i < allTiles.Count; i++) {
                if (obj.tile.name == allTiles[i].name) {
                    tiles.Add(allTiles[i]);
                }
            }
            
            active.Add(obj.activate);
        }
    }

    private void UpdateTiles(GameObject obj) {
        // Loop through our waypoints array.
        for (int i = 0; i < waypoints.Count; i++) {
            // If the object matches one of our waypoints..
            if (obj.name == waypoints[i].name) {
                // Set the corresponding tile to active or inactive.
                tiles[i].SetActive(active[i]);
                print("obj: " + obj + " waypoint: " + waypoints[i] + ", tile: " + tiles[i]);
            }
        }
    }
}
