using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashMarkController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {

            collision.gameObject.GetComponent<playerInventory>().flashAmount++;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "bottom")
        {
            Destroy(gameObject);
        }
    }
}
