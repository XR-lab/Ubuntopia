using UnityEngine;
using UnityEngine.Timeline;

[CreateAssetMenu(fileName = "_SoundCollection", menuName = "ScriptableObjects/New Sound Collection", order = 1)]
public class SoundCollection : ScriptableObject
{
    public SoundClip[] soundCollection;
    public TimelineAsset[] timelineAssetsCollection;
}