using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_SoundCollection", menuName = "ScriptableObjects/New Sound Collection", order = 1)]
public class SoundCollection : ScriptableObject
{
    public List<SoundClip> soundCollection;
}