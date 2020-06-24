using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {
    [SerializeField] private WaypointTileData _data;

    [SerializeField] private List<GameObject> waypoints;
    [SerializeField] private List<GameObject> tiles;
    [SerializeField] private List<bool> active;
    
    private Dictionary<GameObject, bool> tileActivation = new Dictionary<GameObject, bool>();

    private void Start() {
        InitializeDictionaries();
    }

    private void InitializeDictionaries() {
        foreach (var obj in _data.waypointTileData) {
            waypoints.Add(obj.waypoint);
            tiles.Add(obj.tile);
            active.Add(obj.activate);
        }
        
        // InitializeTiles();
    }

    // private void InitializeTiles() {
    //     for (int i = 0; i < tiles.Count; i++) {
    //         tiles[i].SetActive(tileActivation[active[i]]);
    //     }
    // }
}
