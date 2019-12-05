using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCubeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "player") 
        {
            collision.gameObject.GetComponent<playerHP>().loseHP(100);
        }
        

    }
}
