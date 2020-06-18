using System.Collections.Generic;
using UnityEngine;

public class BackToRoad : MonoBehaviour
{
    [SerializeField] private List<GameObject> _correctionTarget;
    private GameObject _previousTarget;
    private Movement _playerMovement;
    private ManualFlight _manualFlight;

    private void Start()
    {
        _playerMovement = GameObject.FindWithTag("Harish").GetComponent<Movement>();
        _manualFlight = GameObject.FindWithTag("Player").GetComponent<ManualFlight>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("HarishLeft"))
        {
            _manualFlight.SetBoundaryState(true);
            _previousTarget = _playerMovement.GetTarget();
            _playerMovement.SetTarget(_correctionTarget[0]);
        }

        if (other.transform.CompareTag("HarishRight"))
        {
            _manualFlight.SetBoundaryState(true);
            _previousTarget = _playerMovement.GetTarget();
            _playerMovement.SetTarget(_correctionTarget[1]);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("HarishLeft") || other.transform.CompareTag("HarishRight") )
        {
            _manualFlight.SetBoundaryState(false);
            other.GetComponent<Movement>().SetTarget(_previousTarget);
        }
    }
}
