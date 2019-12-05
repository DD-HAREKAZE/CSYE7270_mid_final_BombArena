
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{

    float t1;
    float t2;
    public GameObject flashParticle;
    public GameObject flashExplodeSphere;
    Vector3 temp = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        t1 = Time.time;
        t2 = t1 + 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= t2)
        {
            temp = this.gameObject.GetComponent<Transform>().position;
            temp.y = 0;
            Instantiate(flashParticle, this.gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Instantiate(flashExplodeSphere, temp, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
