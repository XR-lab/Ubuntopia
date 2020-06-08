using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioManager))]
public class AddClip : Editor
{
	// ______________________________________________________________________________________________/ Private Variables
	private bool _new = false;
	private AudioManager _manager;
	private SerializedProperty _prop;
	
	private string name;
	private AudioClip clip;
	[Range(0f, 1f)]private float volume = 1f;
	[Range(-3f, 3f)] private float pitch = 1f;
	private bool loop = false;
	private bool playOnAwake = false;
	[Range(0f, 1f)]private float spatialBlend = 0;

	void OnEnable()
	{
		_prop = serializedObject.FindProperty("clip");
	}

	// _________________________________________________________________________________________________/ OnInspectorGUI
	public override void OnInspectorGUI()
	{
		_manager = (AudioManager) target;
		
		if (!_new)
		{
			DrawDefaultInspector();
			if (GUILayout.Button("Make a new SoundClip"))
			{
				_new = true;
				name = "";
				_manager.clip = null;
				volume = 1f;
				pitch = 1f;
				loop = false;
				playOnAwake = false;
				spatialBlend = 0;
			}
		}
		else
		{
			if (GUILayout.Button("Cancel"))
			{
				_new = false;
			}
			
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("Name: ");
			name = EditorGUILayout.TextField(name);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.PropertyField(_prop, new GUIContent("Clip: "));
			
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("Volume: ");
			volume = EditorGUILayout.Slider(volume, 0f, 1f);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("Pitch: ");
			pitch = EditorGUILayout.Slider(pitch, -3f, 3f);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("Loop: ");
			loop = EditorGUILayout.Toggle(loop);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("Play on Awake: ");
			playOnAwake = EditorGUILayout.Toggle(playOnAwake);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("3D noise (0 = No, 1 = Yes): ");
			spatialBlend = EditorGUILayout.Slider(spatialBlend, 0f, 1f);
			EditorGUILayout.EndHorizontal();
			
			serializedObject.ApplyModifiedProperties();
			
			if (GUILayout.Button("Create the SoundClip"))
			{
				MakeObj();
				_new = false;
			}
		}
		
		
	}

	private void MakeObj()
	{
		SoundClip soundthingy = ScriptableObject.CreateInstance<SoundClip>();

		soundthingy.name = name;
		soundthingy.clip = _manager.clip;
		soundthingy.volume = volume;
		soundthingy.pitch = pitch;
		soundthingy.loop = loop;
		soundthingy.playOnAwake = playOnAwake;
		soundthingy.spatialBlend = spatialBlend;
		
		AssetDatabase.CreateAsset(soundthingy,"Assets/Audio/" + name + ".asset");
		AssetDatabase.SaveAssets();

		SoundCollection s = (SoundCollection)AssetDatabase.LoadAssetAtPath("Assets/Audio/_SoundCollection.asset", typeof(SoundCollection));
		Debug.Log(s);
		s.soundCollection.Add(soundthingy);
		AssetDatabase.SaveAssets();
	}
}
