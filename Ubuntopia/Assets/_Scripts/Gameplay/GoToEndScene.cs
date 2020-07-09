using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToEndScene : MonoBehaviour {
    [Unity.Collections.ReadOnly]
    [SerializeField, Header("Default duration for outro clip is 22 seconds.")] 
    private float outroDuration = 22f;

    private void Start() {
        StartCoroutine(SwitchScene());
    }

    private IEnumerator SwitchScene() {
        // Wait for outro clip to end.
        yield return new WaitForSeconds(outroDuration);
        
        // Switch.
        SceneManager.LoadScene("EndScreen");
    }
}
