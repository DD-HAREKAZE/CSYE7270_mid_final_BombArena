using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGD5 : MonoBehaviour
{
    // Start is called before the first frame update
    float t1;
    float t2;
    public GameObject RGD5Particle;
    public GameObject RGD5ExplodeSphere;
    Vector3 temp = new Vector3();
    void Start()
    {
        t1 = Time.time;
        t2 = t1 + 4.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time >= t2) 
        {
            temp = this.gameObject.GetComponent<Transform>().position;
            temp.y = 0;
            Instantiate(RGD5Particle, this.gameObject.GetComponent<Transform>().position,Quaternion.identity);
            Instantiate(RGD5ExplodeSphere, temp, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
    
}
