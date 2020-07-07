using UnityEngine;

public class ManualFlight : MonoBehaviour
{
	// _______________________________________________________________________________________/ SerializeField Variables
	[SerializeField] private Transform _rightHand, _leftHand;
	[SerializeField] private Transform _player;
	[SerializeField] private RotationFix _rotationFix;
	[SerializeField] private Movement _movement;
	[SerializeField] private ToggleWings _toggle;

	// ______________________________________________________________________________________________/ Private Variables
	private bool _manualMovementActive = false, _outOffBoundarys = false;
	private float _maxSpeed;
	private HandsToWings _handsToWings;
	
    // __________________________________________________________________________________________________________/ Start
    private void Start()
    {
	    _maxSpeed = _movement.GetMaxSpeed();
	    _handsToWings = GetComponent<HandsToWings>();
    }	

    // _________________________________________________________________________________________________________/ Update
    private void Update()
    {
	    if(_outOffBoundarys) return;
	    if (Vector3.Distance(_rightHand.position, _leftHand.position) >= 0.6f)
	    {
		    Move();
		    if (_manualMovementActive) return;
		    _manualMovementActive = true;
			_movement.SetActive(false);
			_toggle.SetManual(true);
	    }
	    else
	    {
		    if (!_manualMovementActive) return;
		    _manualMovementActive = false;
			_movement.SetActive(true);
			_toggle.Toggle();
	    }
    }
    
    // ___________________________________________________________________________________________________________/ Move
    private void Move()
    {
	    _player.transform.position += _player.transform.forward * Time.deltaTime * _maxSpeed;
	    float difrence = (_leftHand.position.y - _rightHand.position.y) / 2.5f;
	    _player.Rotate(0, difrence, 0);
	    _handsToWings.RotateWings(difrence);
	    _rotationFix.Rotate(difrence);
    }
    
    // _______________________________________________________________________________________________/ SetBoundaryState
    public void SetBoundaryState(bool state)
    {
	    _outOffBoundarys = state;
	    _manualMovementActive = false;
	    _toggle.SetManual(Vector3.Distance(_rightHand.position, _leftHand.position) >= 0.6f);
    }
}
