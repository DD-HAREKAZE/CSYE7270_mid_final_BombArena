using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    float t1;
    float t2;
    public GameObject stunParticle;
    public GameObject stunExplodeSphere;
    Vector3 temp = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        t1 = Time.time;
        t2 = t1 + 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= t2)
        {
            temp = this.gameObject.GetComponent<Transform>().position;
            temp.y = 0;
            Instantiate(stunParticle, this.gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Instantiate(stunExplodeSphere, temp, Quaternion.identity);
            Destroy(this.gameObject);
        }
        
    }
}
