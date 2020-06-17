using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Transform _collectible;
    private MistReducer _mistReducer;

    public float minDistance;
    
   private void Start()
   {
       _collectible = GameObject.FindWithTag("Relic").GetComponent<Transform>();
       _mistReducer = GameObject.FindWithTag("MistManager").GetComponent<MistReducer>();
   }

   private void FixedUpdate()
   {
       if (Vector3.Distance(this.gameObject.transform.position, _collectible.position) <= minDistance)
       {
           _collectible.gameObject.GetComponent<Collect>().Collected();
           _mistReducer.MistDown();
       }
   }    
}
