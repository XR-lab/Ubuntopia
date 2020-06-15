using UnityEngine;

public class ManualFlight : MonoBehaviour
{
	// _______________________________________________________________________________________________/ Public Variables

	// _______________________________________________________________________________________/ SerializeField Variables
	[SerializeField] private Transform _rightHand, _leftHand;
	[SerializeField] private Transform _player;
	
	// ______________________________________________________________________________________________/ Private Variables
	private bool _manualMovementActive = false;
	private float _maxSpeed;
	private Movement _movement;
	
	// __________________________________________________________________________________________________________/ Awake
    private void Awake()
    {
        
    }
	
    // __________________________________________________________________________________________________________/ Start
    private void Start()
    {
	    _movement = _player.GetComponent<Movement>();
	    _maxSpeed = _movement.GetMaxSpeed();
    }	

    // _________________________________________________________________________________________________________/ Update
    private void Update()
    {
	    if (Vector3.Distance(_rightHand.position, _leftHand.position) >= 1f)
	    {
		    Move();
			if (!_manualMovementActive)
			{
				_manualMovementActive = true;
				_movement.SetActive(false);
			}
	    }
	    else
	    {
			if (_manualMovementActive)
			{
				_manualMovementActive = false;
				_movement.SetActive(true);
			}
	    }
    }
    
    // _________________________________________________________________________________________________________/ Update
    private void Move()
    {
	    _player.transform.position += _player.transform.forward * Time.deltaTime * _maxSpeed;
	    float difrence = _leftHand.position.y - _rightHand.position.y;
	    _player.Rotate(0, difrence, 0);
    }
}
