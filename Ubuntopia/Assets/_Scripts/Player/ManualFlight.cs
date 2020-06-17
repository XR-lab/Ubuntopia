using UnityEngine;

public class ManualFlight : MonoBehaviour
{
	// _______________________________________________________________________________________/ SerializeField Variables
	[SerializeField] private Transform _rightHand, _leftHand;
	[SerializeField] private Transform _player;
	
	// ______________________________________________________________________________________________/ Private Variables
	private bool _manualMovementActive = true;
	private float _maxSpeed;
	private Movement _movement;
	private RotationFix _rotationFix;
	private bool _outOffBoundarys = false;
	
    // __________________________________________________________________________________________________________/ Start
    private void Start()
    {
	    _movement = _player.GetComponent<Movement>();
	    _maxSpeed = _movement.GetMaxSpeed();
	    _rotationFix = GetComponent<RotationFix>();
    }	

    // _________________________________________________________________________________________________________/ Update
    private void Update()
    {
	    if(_outOffBoundarys) return;
	    _player.transform.position += _player.transform.forward * Time.deltaTime * _maxSpeed;
	    if (Vector3.Distance(_rightHand.position, _leftHand.position) >= 0.6f)
	    {
		    Move();
		    if (_manualMovementActive) return;
		    _manualMovementActive = true;
			_movement.SetActive(false);
	    }
	  //   else
	  //   {
		 //    if (!_manualMovementActive) return;
		 //    _manualMovementActive = false;
			// _movement.SetActive(true);
	  //   }
    }
    
    // ___________________________________________________________________________________________________________/ Move
    private void Move()
    {
	    float difrence = (_leftHand.position.y - _rightHand.position.y) / 2.5f;
	    _player.Rotate(0, difrence, 0);
	    _rotationFix.Rotate(difrence);
    }
    
    // _______________________________________________________________________________________________/ SetBoundaryState
    private void SetBoundaryState(bool state)
    {
	    _outOffBoundarys = state;
    }
}
