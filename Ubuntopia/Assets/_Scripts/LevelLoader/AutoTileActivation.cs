using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class AutoTileActivation : MonoBehaviour {
    /// <summary>
    /// To use this script, you must place the waypoints in the correct order in the __Waypoints parent.
    /// Also, every tile must be placed in the correct order in the __Tiles parent.
    /// </summary>
    
    [SerializeField, Tooltip("Drag tiles parent GameObject here")]
    private GameObject tilesParent;
    
    [SerializeField, Tooltip("Drag waypoints parent GameObject here")]
    private GameObject waypointParent;

    [SerializeField, Tooltip("How many tiles should be visable in front the player.")]
    private int limit = 1;

    private List<GameObject> waypoints = new List<GameObject>();
    private List<GameObject> tiles = new List<GameObject>();
    private Dictionary<GameObject, GameObject> waypointTileMap = new Dictionary<GameObject, GameObject>();

    // References.
    [SerializeField, Tooltip("Drag Harish here (from scene hierarchy).")]
    private Waypoints _playerWaypoints;

    private void Start() {
       InitializeWaypointList();
       InitializeTilesList();
       LinkWaypointWithTiles();

       // Subscribe to event.
       _playerWaypoints.Arrived += SetActiveStateForTile;
    }

    // Unsubscribe from event on destroy.
    private void OnDestroy() {
        _playerWaypoints.Arrived -= SetActiveStateForTile;
    }

    private void InitializeWaypointList() {
        int counter = 0;
        foreach (Transform obj in waypointParent.transform) {
            obj.gameObject.name = "Waypoint_" + counter;
            counter++;
            waypoints.Add(obj.gameObject);
        }
    }

    private void InitializeTilesList() {
        int counter = 0;
        foreach (Transform obj in tilesParent.transform) {
            obj.gameObject.name = "Tile_" + counter;
            counter++;
            tiles.Add(obj.gameObject);
        }
    }

    private void LinkWaypointWithTiles() {
        for (int i = 0; i < waypoints.Count; i++) {
            // Create raycast on each waypoint, aiming downwards.
            RaycastHit hit;
            Physics.Raycast(waypoints[i].transform.position, Vector3.down, out hit);
            
            // Loop through tiles list to find a match.
            for (int t = 0; t < tiles.Count; t++) {
                if (hit.collider == tiles[t].GetComponent<Collider>()) {
                    // Create link between waypoint and tile.
                    waypointTileMap.Add(waypoints[i], tiles[t]);
                    // print("Link created! " + waypoints[i] + " + " + tiles[t]);
                }
            }
        }
    }

    // If player reached waypoint, (de)activate tiles according to the waypoint position.
    private void SetActiveStateForTile(GameObject obj) {
        if (waypointTileMap.ContainsKey(obj)) {
            for (int i = 0; i < tiles.Count; i++) {
                // If tiles[i] is connected to our current waypoint, stop deactivating.
                if (tiles[i] == waypointTileMap[obj]) {
                    // Set new limit.
                    int newLimit = limit;
                    newLimit += i + 2;

                    // Activate tiles around player.
                    for (int l = i; l < newLimit; l++) {
                        if (l < tiles.Count) {
                            // In front of the player.
                            tiles[l].GetComponent<MeshRenderer>().enabled = true;
                            // If the tile has children, disable children gameobjects.
                            if (tiles[l].transform.childCount > 0) {
                                foreach (Transform child in tiles[l].transform) {
                                    child.gameObject.SetActive(true);
                                }
                            }
                            
                            // Behind the player.
                            // Create new variable based on current limit, to calculate tile integer behind the player.
                            int b = l - limit;
                            if (b >= 0) {
                                tiles[b].GetComponent<MeshRenderer>().enabled = true;
                                // If the tile has children, disable children gameobjects.
                                if (tiles[b].transform.childCount > 0) {
                                    foreach (Transform child in tiles[b].transform) {
                                        child.gameObject.SetActive(true);
                                    }
                                }
                            }
                        }
                    }
                    // Exit function.
                    return;
                }
                
                // Deactivate tiles until reaching the back-limit.
                tiles[i].GetComponent<MeshRenderer>().enabled = false;
                // If the tile has children, disable children gameobjects.
                if (tiles[i].transform.childCount > 0) {
                    foreach (Transform child in tiles[i].transform) {
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    
    
    // Backup code.
    
    // Not used at the moment.
    // Deactivate after linking waypoints and tiles.
    // private void DeactivateAfterLink() {
    //     for (int i = limit; i < tiles.Count; i++) {
    //         tileActiveMap[tiles[i]] = false;
    //         tiles[i].SetActive(tileActiveMap[tiles[i]]);
    //     }
    // }
    // 
    // // (De)Activates gameobjects rather than dis/enables meshrenderers.
    // // If player reached waypoint, (de)activate tiles according to the waypoint position.
    // private void SetActiveStateForTile(GameObject obj) {
    //     if (waypointTileMap.ContainsKey(obj)) {
    //         for (int i = 0; i < tiles.Count; i++) {
    //             // If tiles[i] is connected to our current waypoint, stop deactivating.
    //             if (tiles[i] == waypointTileMap[obj]) {
    //                 // Set new limit.
    //                 int newLimit = limit;
    //                 newLimit += i + 2;
    //                 tileActiveMap[tiles[i]] = true;
    //                 tiles[i].SetActive(tileActiveMap[tiles[i]]);
    //
    //                 // Activate tiles around player.
    //                 for (int l = i; l < newLimit; l++) {
    //                     if (l < tiles.Count) {
    //                         // In front of the player.
    //                         tileActiveMap[tiles[l]] = true;
    //                         tiles[l].SetActive(tileActiveMap[tiles[l]]);
    //                         
    //                         // Behind the player.
    //                         int b = l - limit;
    //                         if (b >= 0) {
    //                             tileActiveMap[tiles[b]] = true;
    //                             tiles[b].SetActive(tileActiveMap[tiles[b]]);
    //                         }
    //                     }
    //                 }
    //                 
    //                 return;
    //             }
    //             
    //             // Deactivate tiles behind us.
    //             tileActiveMap[tiles[i]] = false;
    //             tiles[i].SetActive(tileActiveMap[tiles[i]]);
    //         }
    //     }
    // }
}
