using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject[] _collectible;

    public float minDistance;
    
   private void Start()
   {
       _collectible = GameObject.FindGameObjectsWithTag("Relic");
   }

   private void FixedUpdate()
   {
       for (int i = 0; i <= _collectible.Length; i++)
       {
           if (Vector3.Distance(this.gameObject.transform.position, _collectible[i].transform.position) <= minDistance)
           {
               _collectible[i].GetComponent<Collect>().Collected();
           }
       }
   }    
}
