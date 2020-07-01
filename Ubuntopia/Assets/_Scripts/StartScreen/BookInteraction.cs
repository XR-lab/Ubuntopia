using UnityEngine;

public class BookInteraction : MonoBehaviour
{

    [SerializeField] private IntroManager _introManager;
    private bool _enumeratorStarted = false;
    [SerializeField] private Animator _bookAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (!_enumeratorStarted)
        {
            _enumeratorStarted = true;
            _bookAnimator.SetTrigger("Open");
            _introManager.StartIntro();
        }
    }
}
