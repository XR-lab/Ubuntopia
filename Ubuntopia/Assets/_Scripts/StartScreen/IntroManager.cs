using System.Collections;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public delegate void nextPhaseStarter();
    public nextPhaseStarter nextPhase;
    
    [SerializeField]
    private SceneSwitcher _sceneSwitcher;
    
    void Start()
    {
        nextPhase += _sceneSwitcher.SwitchScenes;
    }

    public void StartIntro()
    {
        StartCoroutine(Intro());
    }
    
    private IEnumerator Intro()
    {
        string clipName = "Intro";
        AudioManager am = AudioManager.instance;
        float waitTimer = am.GetClipData(clipName).clip.length;
        am.Play(clipName);
        
        yield return new WaitForSeconds(waitTimer);

        nextPhase();
    }
}
