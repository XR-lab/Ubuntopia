using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private int _found = 0;

    public int total;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Artifact")
        {
            _found++;
            //other.GetComponent<"Script with events">().play Voice line that 
            Destroy(other.gameObject);
            if (_found == total)
            {
                //Throw event for when you collect all artifacts;
            }
        }
    }
}
