using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelLoader))]
public class AddWaypointTileLink : Editor {
	#region _________________________________________________________________________________________/ Private Variables
	private bool _new = false;
	private LevelLoader _levelLoader;
	private SerializedProperty _prop;
	
	private Object waypoint;
	private Object tile;
	private bool activate = false;
	#endregion
	
	void OnEnable() {
		_prop = serializedObject.FindProperty("waypoint");
	}
	
	public override void OnInspectorGUI() {
		_levelLoader = (LevelLoader) target;
		
		if (!_new) {
			DrawDefaultInspector();
			if (GUILayout.Button("Make a new Waypoint Tile Link")) {
				_new = true;
				waypoint = null;
				tile = null;
				activate = false;
			}
			
		} else {
			if (GUILayout.Button("Cancel")) {
				_new = false;
			}
			
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("Waypoint: ");
			waypoint = EditorGUILayout.ObjectField(waypoint, typeof(GameObject), true);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("Tile: ");
			tile = EditorGUILayout.ObjectField(tile, typeof(GameObject), true);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("Activate?");
			activate = EditorGUILayout.Toggle(activate);
			EditorGUILayout.EndHorizontal();

			serializedObject.ApplyModifiedProperties();
			
			if (GUILayout.Button("Create the Link")) {
				MakeObj();
				_new = false;
			}
		}
		
		
	}

	// ________________________________________________________________________________________________________/ MakeObj
	private void MakeObj() {
		WaypointTileLink link = ScriptableObject.CreateInstance<WaypointTileLink>();

		// Assign variables.
		link.linkName = waypoint.name + "_" + tile.name + "_" + activate;
		link.waypoint = waypoint as GameObject;
		link.tile = tile as GameObject;
		link.activate = activate;

		// Save asset.
		AssetDatabase.CreateAsset(link,"Assets/_Scripts/LevelLoader/Links/" + link.linkName + ".asset");
		AssetDatabase.SaveAssets();

		WaypointTileData w = (WaypointTileData)AssetDatabase.LoadAssetAtPath("Assets/_Scripts/LevelLoader/_WaypointTileData.asset", typeof(WaypointTileData));
		Debug.Log(w + " created!");
		w.waypointTileData.Add(link);
		AssetDatabase.SaveAssets();
	}
}
