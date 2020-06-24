using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTileLink : ScriptableObject {
    public string linkName;
    public GameObject waypoint;
    public string waypointName;
    public GameObject tile;
    public string tileName;
    public bool activate = false;
}
