using UnityEngine;

//[CreateAssetMenu(fileName = "Clip", menuName = "ScriptableObjects/New Sound Clip", order = 2)]
public class SoundClip : ScriptableObject
{
    public AudioClip clip;

    [Range(0f, 1f)]public float volume = 1f;
    [Range(-3f, 3f)] public float pitch = 1f;
    public bool loop = false;
    public bool playOnAwake = false;
    [Range(0f, 1f)]public float spatialBlend = 0;
}
