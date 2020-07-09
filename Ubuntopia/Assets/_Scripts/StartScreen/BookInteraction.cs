using System.Collections.Generic;
using UnityEngine;

public class BookInteraction : MonoBehaviour
{

    [SerializeField] private IntroManager _introManager;
    private bool _enumeratorStarted = false;
    [SerializeField] private Animator _bookAnimator;
    [SerializeField] private List<GameObject> _otherBooks;
    [SerializeField] private Languages _bookLanguage;
    [SerializeField] private GameObject _flag;

    private void OnTriggerEnter(Collider other)
    {
        if (!_enumeratorStarted)
        {
            _enumeratorStarted = true;
            AudioManager am = AudioManager.instance;
            am.SetLanguage(_bookLanguage);
            DisableOtherBooks();
            _flag.SetActive(false);
            _bookAnimator.SetTrigger("Open");
            _introManager._textureChanger = GetComponent<TextureChanger>();
            _introManager.StartIntro();
        }
    }

    private void DisableOtherBooks()
    {
        if (_otherBooks.Count <= 0) return;
        for (int i = 0; i < _otherBooks.Count; i++)
        {
            _otherBooks[i].SetActive(false);
        }
    }
}
