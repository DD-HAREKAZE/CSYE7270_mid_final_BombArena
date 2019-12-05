using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashParticleController : MonoBehaviour
{
    float t1;
    float t2;
    // Start is called before the first frame update
    void Start()
    {
        t1 = Time.time;
        t2 = t1 + 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= t2)
        {
            Destroy(gameObject);
        }
    }
}