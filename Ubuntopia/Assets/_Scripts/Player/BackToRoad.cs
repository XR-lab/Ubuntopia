using UnityEngine;

public class BackToRoad : MonoBehaviour
{
    [SerializeField]private Movement _playerMovement;
    [SerializeField]private ManualFlight _manualFlight;

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
        }
    }
}
