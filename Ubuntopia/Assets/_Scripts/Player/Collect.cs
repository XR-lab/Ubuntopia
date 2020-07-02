using UnityEngine;

public class Collect : MonoBehaviour {
    [SerializeField] private MistReducer _mist;
    private GameObject artifactMist;
    
    public void Collected() {
        // Enter follow uo code on collection here(Cutscene/other code).
        _mist.MistDown();
        artifactMist = _mist.gameObject;
        artifactMist.GetComponent<AudioSource>().Stop();
        GameObject.Destroy(this.gameObject);
    }
}
