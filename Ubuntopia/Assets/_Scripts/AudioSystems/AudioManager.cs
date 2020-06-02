using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // _______________________________________________________________________________________________/ Public Variables
    public static AudioManager instance;
    public int amountOfAudioSources = 10;
    
    // ____________________________________________________________________________________________/ 'Private' Variables
    [SerializeField]private SoundCollection _sounds;
    
    // ______________________________________________________________________________________________/ Private Variables
    private AudioSource[] _sources;

    // __________________________________________________________________________________________________________/ Awake
    void Awake()
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
        
        _sources = new AudioSource[amountOfAudioSources];

        GameObject audioSource = new GameObject();
        audioSource.AddComponent<AudioSource>();
        for (int i = 0; i < amountOfAudioSources; i++)
        {
            audioSource.name = "audioSource: " + i;
            _sources[i] = Instantiate(audioSource, transform).GetComponent<AudioSource>();
        }
    }
}
