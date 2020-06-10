using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Transform _collectible;

    public float minDistance;
    
   private void Start()
   {
       _collectible = GameObject.FindWithTag("Relic").GetComponent<Transform>();
   }

   private void FixedUpdate()
   {
       if (Vector3.Distance(this.gameObject.transform.position, _collectible.position) <= minDistance)
       {
           _collectible.gameObject.GetComponent<Collect>().Collected();
       }
   }
}
