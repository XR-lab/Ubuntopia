using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class MistReducer : MonoBehaviour
{
    public List<ParticleSystem> mists = new List<ParticleSystem>();
    
    private bool _reducing;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            MistDown();
    }

    public void MistDown()
    {
        for (int i = 0; i < mists.Count; i++)
        {
            Debug.Log("Here");
            var em = mists[i].emission;//.enabled = false;
            em.enabled = false;
        }
    }
}
