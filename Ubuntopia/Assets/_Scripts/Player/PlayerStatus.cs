using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    private enum Status { Idle, Grounded, Mounted, Flying }
    private Status playerStatus;
    
    // References.
    [Tooltip("Drag player here.")]
    [SerializeField] private Mounting _mounting;

    private void Start() {
        _mounting.PlayerHasMounted += ChangeToMounted;
    }

    private void ChangeToMounted() {
        playerStatus = Status.Mounted;
    }

    private void ChangeToGrounded() {
        playerStatus = Status.Grounded;
    }

    private void ChangeToFlying() {
        playerStatus = Status.Flying;
    }

    private void ChangeToIdle() {
        playerStatus = Status.Idle;
    }

    public int GetStatus() {
        return (int) playerStatus;
    }
    
}
