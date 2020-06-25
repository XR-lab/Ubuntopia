using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTileLink : ScriptableObject {
    public string linkName;
    public GameObject waypoint;
    public GameObject tile;
    public bool activate = false;
}
