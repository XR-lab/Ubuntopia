using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private List<GameObject> _collectible;
    private int _amountCollected = 0;

    [SerializeField] private float minDistance;

    private void FixedUpdate()
   {
       if (_amountCollected < _collectible.Count)
       {
           if (Vector3.Distance(this.gameObject.transform.position, _collectible[_amountCollected].transform.position) <= minDistance)
           {
               _collectible[_amountCollected].GetComponent<Collect>().Collected();
               _amountCollected++;
           }
       }
   }    
}
