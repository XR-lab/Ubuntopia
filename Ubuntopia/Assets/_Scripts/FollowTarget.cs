using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	// _______________________________________________________________________________________/ SerializeField Variables
	[SerializeField] private Transform _target;
	[SerializeField] private Vector3 _offset;
	
    // _____________________________________________________________________________________________________________/ Update
    private void Update()
    {
	    transform.position = _target.position + _offset;
    }
}
