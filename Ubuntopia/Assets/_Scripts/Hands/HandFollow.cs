using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollow : MonoBehaviour
{

    [SerializeField] private GameObject _handModel;
    [SerializeField] private Transform _horseTransform;
    
    private void OnCollisionEnter(Collision other)
    {
        _handModel.transform.parent = other.transform;
        //_handModel.transform.position = new Vector3(transform.position.x, _handModel.transform.position.y, transform.position.z);
        _handModel.transform.localPosition = new Vector3(0,_handModel.transform.localPosition.y,0);
        
    }

    private void OnCollisionExit(Collision other)
    {
        _handModel.transform.parent = transform;
        _handModel.transform.localPosition = new Vector3();
        _handModel.transform.localRotation = new Quaternion();
    }
}
