using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // _______________________________________________________________________________________________/ Public Variables
    public static AudioManager instance;
    [HideInInspector] public AudioClip clip;
    
    // ____________________________________________________________________________________________/ 'Private' Variables
    [SerializeField] private SoundCollection _sounds;
    
    // ______________________________________________________________________________________________/ Private Variables
    private Dictionary<string, SoundClip> _clips = new Dictionary<string, SoundClip>();
    [SerializeField]
    private List<AudioSource> _available = new List<AudioSource>();
    [SerializeField]
    private List<AudioSource> _playing = new List<AudioSource>();
    private int amountOfAudioSources = 10;

    // __________________________________________________________________________________________________________/ Awake
    private void Awake()
    {
        DontDestroy();
        SetupAudioSources();
        LoadSoundCollection();
    }

    // __________________________________________________________________________________________________/ Don't Destroy
    private void DontDestroy()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    // _________________________________________________________________________________________________________/ Update
    private void Update() {
        foreach (var p in _playing) {
            if (!p.isPlaying) {
                _available.Add(p);
                _playing.Remove(p);
                return;
            }
        }
    }
    
    // ____________________________________________________________________________________________/ Setup Audio Sources
    private void SetupAudioSources()
    {
        GameObject audioSource = new GameObject();
        audioSource.AddComponent<AudioSource>();
        for (int i = 0; i < amountOfAudioSources; i++)
        {
            _available.Add( Instantiate(audioSource, transform).GetComponent<AudioSource>());
            _available[i].name = "audioSource: " + i;
        }
        Destroy(audioSource);
    }
    
    // __________________________________________________________________________________________/ Load Sound Collection
    private void LoadSoundCollection()
    {
        foreach (var s in _sounds.soundCollection)
        {
            _clips.Add(s.name, s);
            if(s.playOnAwake)
                Play(s.name);
        }
    }
    
    // ___________________________________________________________________________________________________________/ Play
    public void Play(string name) {
        Play(name, transform);
        print("playing: " + name);
    }
    public void Play(string name, Transform target)
    {
        if (!CheckAvailable()) return; 
        
        SoundClip c = _clips[name];
        if(c == null){print("No such name found!"); return;}
        AudioSource s = _available[0];
        SetSourceVariables(s, c, target);
    }
    
    // ____________________________________________________________________________________________________/ Play Random
    public void PlayRandom(string name, int numberOfVariations)
    {
        int random = Random.Range(0, numberOfVariations);
        Play(name+random, transform);
        print("playing: " + name+random);
    }
    
    public void PlayRandom(string name, int numberOfVariations, Transform target)
    {
        int random = Random.Range(0, numberOfVariations);
        Play(name+random, target);
    }

    // ________________________________________________________________________________________________/ Check Available
    private bool CheckAvailable()
    {
        if (_available.Count != 0)
            return true;
        else
        {
            print("no available audio players at this moment");
            return false;
        }
    }

    // __________________________________________________________________________________________________/ Set Variables
    private void SetSourceVariables(AudioSource s, SoundClip c, Transform target)
    {
        s.clip = c.clip;
        s.volume = c.volume;
        s.pitch = c.pitch;
        s.loop = c.loop;
        s.playOnAwake = c.playOnAwake;
        s.spatialBlend = c.spatialBlend;
        s.transform.parent = target;
        s.Play();
        _playing.Add(s);
        _available.RemoveAt(0);
    }
    
    // ___________________________________________________________________________________________________________/ Stop
    public void Stop(string name)
    {
        foreach (var p in _playing)
        {
            if (p.clip == _clips[name].clip)
            {
                p.Stop();
                _available.Add(p);
                _playing.Remove(p);
                return;
            }
        }
        print(name + " is not playing or is misspelled");
    }

    // ____________________________________________________________________________________________________/ GetClipData
    public SoundClip GetClipData(string name)
    {
        SoundClip c = _clips[name];
        if(c == null){print("No such name found!"); return null;}
        return c;
    }
}
