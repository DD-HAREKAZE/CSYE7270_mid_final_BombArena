using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject molotovEffect;

    void Start()
    {
        
    }

    // Update is called once per frame

    void FixedUpdate() 
    {
        
    }

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "ground") 
        {
            Instantiate(molotovEffect, this.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "bottom")
        {           
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("hit player");
            Vector3 position = new Vector3();
            position.x = this.GetComponent<Transform>().position.x;
            position.y = 0;
            position.z = this.GetComponent<Transform>().position.z;
            Instantiate(molotovEffect, position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
}
