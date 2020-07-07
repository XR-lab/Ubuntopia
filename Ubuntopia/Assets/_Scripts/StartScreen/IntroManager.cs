using System.Collections;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public delegate void nextPhaseStarter();
    public nextPhaseStarter nextPhase;

    [SerializeField]
    private SceneSwitcher _sceneSwitcher;

    private Timer _timer;
    
    void Start()
    {
        _timer = FindObjectOfType<Timer>();
        nextPhase += _timer.StartTimer;
        nextPhase += _sceneSwitcher.SwitchScenes;
    }

    public void StartIntro()
    {
        StartCoroutine(Intro());
    }
    
    private IEnumerator Intro() {
        string clipName = "Intro_Balla_";
        AudioManager am = AudioManager.instance;
        string introName = am.PlayLanguage(clipName);
        float waitTimer = am.GetClipData(introName).clip.length;
        
        yield return new WaitForSeconds(waitTimer);
        
        // Turn off sfx. Needs refactor later as it does not belong here.
        am.Stop("Campfire");
        am.GetComponent<SFX_Wind>().isMoving = true;

        // Announce next phase.
        nextPhase();
    }
}
