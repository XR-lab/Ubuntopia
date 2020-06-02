using UnityEngine;

[CreateAssetMenu(fileName = "Clip", menuName = "ScriptableObjects/New Sound Clip", order = 2)]
public class SoundClip : ScriptableObject
{
    public string name;
    
    public AudioClip clip;

    [Range(0f,1f)]public float volume = 1f;
    public bool loop = false;
    public bool playOnAwake = false;
}
