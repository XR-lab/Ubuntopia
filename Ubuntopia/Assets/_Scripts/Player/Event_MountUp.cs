using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_MountUp : MonoBehaviour {
    [Tooltip("Drag player here.")] [SerializeField]
    private Mounting _mounting;

    public void MountUp() {
        _mounting.MountUp();
    }
}

