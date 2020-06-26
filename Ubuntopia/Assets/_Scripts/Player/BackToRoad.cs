using System.Collections.Generic;
using UnityEngine;

public class BackToRoad : MonoBehaviour
{
    private Movement _playerMovement;
    private ManualFlight _manualFlight;

    private void Start()
    {
        _playerMovement = GameObject.FindWithTag("Harish").GetComponent<Movement>();
        _manualFlight = GameObject.FindWithTag("Player").GetComponent<ManualFlight>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Harish"))
        {
            _manualFlight.SetBoundaryState(true);
            _playerMovement.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Harish"))
        {
            _manualFlight.SetBoundaryState(false);
            _playerMovement.SetActive(false);
        }
    }
}
