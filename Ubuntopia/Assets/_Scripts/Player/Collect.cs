using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public void Collected()
    {
        //Enter follow uo code on collection here(Cutscene/other code)
        GameObject.Destroy(this.gameObject);
    }
}
