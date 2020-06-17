using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	// _______________________________________________________________________________________/ SerializeField Variables
	[SerializeField] private Transform _target;
	[SerializeField] private Vector3 _offset;
	
    // _________________________________________________________________________________________________________/ Update
    private void FixedUpdate()
    {
	    Vector3 offset = new Vector3() + 
	                     (_target.right * _offset.x) +
	                     (_target.up * _offset.y) +
	                     (_target.forward * _offset.z);
	    transform.position = _target.position + offset;
    }
}
