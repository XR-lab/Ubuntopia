using UnityEngine;

public class MistReducer : MonoBehaviour
{
    private ParticleSystem mist;
    private bool _reducing;
    private AudioSource source;
    private bool startCounting = false;
    private float counter = 0f;

    private float stopTime = 0;
    [SerializeField]private float mistReducingSpeed = 0.7f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            MistDown();

        if (startCounting) {
            StopArtifactSFX();
        }
    }
    private void Start()
    {
        mist = this.GetComponent<ParticleSystem>();
        source = GetComponent<AudioSource>();
    }

    // Called when artifact is picked up.
    public void MistDown() {
        var em = mist.emission;
        var main = mist.main;
        em.enabled = false;
        main.simulationSpeed = mistReducingSpeed;
        // Activate counter.
        startCounting = true;
    }

    private void StopArtifactSFX() {
        // If object doesn't have audio source, stop function.
        if (!source) {
            startCounting = false;
            return;
        }
        
        counter += Time.deltaTime;
        if (counter >= stopTime) {
            if (source.volume > 0) {
                source.volume -= 1 * Time.deltaTime;
            }
            else {
                // Stop and destroy source, since it's no longer needed.
                source.Stop();
                Destroy(source);
            }
        }
    }
}
