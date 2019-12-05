using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGD5ParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    float t1;
    float t2;
    void Start()
    {
        t1 = Time.time;
        t2 = t1 + 0.8f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time >= t2) 
        {
            Destroy(gameObject);
        }
    }
}
