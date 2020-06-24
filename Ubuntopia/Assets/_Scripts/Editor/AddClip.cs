using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioManager))]
public class AddClip : Editor
{
	#region _________________________________________________________________________________________/ Private Variables
	private bool _new = false;
	private AudioManager _manager;
	private SerializedProperty _prop;
	
	private string name;
	private AudioClip clip;
	private float volume = 1f, pitch = 1f, spatialBlend = 0;
	private bool loop = false, playOnAwake = false;
	#endregion

	// _______________________________________________________________________________________________________/ OnEnable
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
			
			name = EditorGUILayout.TextField(new GUIContent("Name: "), name);
			
			EditorGUILayout.PropertyField(_prop, new GUIContent("Clip: "));
			
			volume = EditorGUILayout.Slider(new GUIContent("Volume: "),  volume, 0f, 1f);
			
			pitch = EditorGUILayout.Slider(new GUIContent("Pitch: "),  pitch, -3f, 3f);
			
			loop = EditorGUILayout.Toggle(new GUIContent("Loop: "), loop);
			
			playOnAwake = EditorGUILayout.Toggle(new GUIContent("Play on Awake: "), playOnAwake);
			
			spatialBlend = EditorGUILayout.Slider(new GUIContent("3D noise (0 = No, 1 = Yes): "),  spatialBlend, 0f, 1f);
			
			serializedObject.ApplyModifiedProperties();
			
			if (GUILayout.Button("Create the SoundClip"))
			{
				MakeObj();
				_new = false;
			}
		}
		
		
	}

	// ________________________________________________________________________________________________________/ MakeObj
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
