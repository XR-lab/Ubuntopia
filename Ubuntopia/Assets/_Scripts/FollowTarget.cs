using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	// _______________________________________________________________________________________/ SerializeField Variables
	[SerializeField] private Transform _target;
	
    // _____________________________________________________________________________________________________________/ Update
    private void Update()
    {
	    transform.position = _target.position + (Vector3.up);
    }
}
