using UnityEngine;

public class BookInteraction : MonoBehaviour
{

    [SerializeField] private IntroManager _introManager;
    private bool _enumeratorStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!_enumeratorStarted)
        {
            _enumeratorStarted = true;
            _introManager.StartIntro();
        }
    }
}
