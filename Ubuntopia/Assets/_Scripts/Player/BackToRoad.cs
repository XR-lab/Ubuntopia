using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BackToRoad : MonoBehaviour
{
    [SerializeField] private bool _left, right;
    [SerializeField] private GameObject _correctionTarget;
    private GameObject _previousTarget;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            var player = other.GetComponent<Movement>();
            _previousTarget = player.GetTarget();
            if (_left)
            {
                player.SetTarget(_correctionTarget);
            }

            if (right)
            {
                player.SetTarget(_correctionTarget);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<Movement>().SetTarget(_previousTarget);
        }
    }
}
