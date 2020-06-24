using UnityEngine;

public class BookScaler : MonoBehaviour
{
    [SerializeField] private GameObject _book;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _wantedTransform;
    private bool _switch = false;
    private float _time = 0f;
    private Vector3 _originalScale;
    private Quaternion _originalRot;
    private Vector3 _difScale;
    
    void Start()
    {
        _originalScale = _book.transform.localScale;
        _originalRot = _book.transform.rotation;
        _difScale = _wantedTransform.localScale - _originalScale;
    }

    void Update()
    {
        AnimatorClipInfo[] clipInfo = _animator.GetCurrentAnimatorClipInfo(0);
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (clipInfo[0].clip.name.Contains("Animation"))
        {
            float currentTime = clipInfo[0].clip.length * stateInfo.normalizedTime;
            float scaleMultiplier = currentTime / clipInfo[0].clip.length;
            _book.transform.localScale = _originalScale + (_difScale * scaleMultiplier);
            _book.transform.rotation = Quaternion.Slerp(_originalRot, _wantedTransform.rotation, scaleMultiplier);
        }
    }
}
