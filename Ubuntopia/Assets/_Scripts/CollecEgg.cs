using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecEgg : MonoBehaviour
{
    
    public void Collected() {
        GameObject.Destroy(this.gameObject);
    }
}


