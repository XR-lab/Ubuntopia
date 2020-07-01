using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_WaypointTileData", menuName = "ScriptableObjects/New WaypointTile Data")]
public class WaypointTileData : ScriptableObject {
    public List<WaypointTileLink> waypointTileData;
}
