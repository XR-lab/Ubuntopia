using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public delegate void nextPhaseStarter();
    public nextPhaseStarter nextPhase;

    [SerializeField]
    private SceneSwitcher _sceneSwitcher;

    private Timer _timer;
    [SerializeField]
    public TextureChanger _textureChanger;
    
    void Start()
    {
        _timer = FindObjectOfType<Timer>();
        nextPhase += _timer.StartTimer;
        nextPhase += _sceneSwitcher.SwitchScenes;
    }

    public void StartIntro()
    {
        StartCoroutine(Intro());
        StartCoroutine(ChangeTexture1());
        StartCoroutine(ChangeTexture2());
    }

    private IEnumerator ChangeTexture1()
    {
        yield return new WaitForSeconds(10);
        _textureChanger.ChangeTexture();
    }
    
    private IEnumerator ChangeTexture2()
    {
        yield return new WaitForSeconds(28);
        _textureChanger.ChangeTexture();
    }
    
    private IEnumerator Intro() {
        string clipName = "Intro_Balla_";
        AudioManager am = AudioManager.instance;
        string introName = am.PlayLanguage(clipName);
        float waitTimer = am.GetClipData(introName).clip.length;
        
        yield return new WaitForSeconds(waitTimer);
        
        // Turn off sfx. Needs refactor later as it does not belong here.
        // We will enter main scene.
        am.Stop("Campfire");
        am.GetComponent<SFX_Wind>().isMoving = true;

        // Announce next phase.
        nextPhase();
    }
}
