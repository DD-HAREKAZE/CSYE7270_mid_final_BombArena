using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class molotovEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private float t1;

    void Start()
    {
        t1 = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time - t1 >= 8.0f) 
        {
            Destroy(this.gameObject);
        }
    }
}
