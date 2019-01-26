﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashStars : MonoBehaviour
{
    private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(particleSystem != null && !particleSystem.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
