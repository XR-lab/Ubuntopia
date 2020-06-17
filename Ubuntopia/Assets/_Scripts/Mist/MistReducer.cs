﻿using System.Collections.Generic;
using UnityEngine;

public class MistReducer : MonoBehaviour
{
    [SerializeField]private List<ParticleSystem> mists;
    private bool _reducing;
    [SerializeField]private float mistReducingSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            MistDown();
    }

    public void MistDown()
    {
        for (int i = 0; i < mists.Count; i++)
        {
            var em = mists[i].emission;//.enabled = false;
            var main = mists[i].main;
            em.enabled = false;
            main.simulationSpeed = mistReducingSpeed;
        }
    }
}
