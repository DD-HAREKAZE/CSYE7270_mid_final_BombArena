using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGD5ExplodeEffect : MonoBehaviour
{


    private float explodeForce = 11000f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Destroy(gameObject);
    }
    

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "player")
        {
            collider.gameObject.GetComponent<playerHP>().loseHP(6);
            Vector3 temp = new Vector3();
            Vector3 explodePosition = transform.position;
            explodePosition.y = 0;
            Vector3 playerPosition = collider.transform.position;
            playerPosition.y = +0.5f;
            Vector3 distanceVector3 = playerPosition - explodePosition;
            float distance = Mathf.Sqrt(distanceVector3.x * distanceVector3.x +distanceVector3.y * distanceVector3.y+ distanceVector3.z + distanceVector3.z);
            if (distance > 0)
            {
                float normalizedDistanceX = distanceVector3.x / distance;
                float normalizedDistanceY = distanceVector3.y / distance;
                float normalizedDistanceZ = distanceVector3.z / distance;
                float realExplodeForce = (1 - distance / 4) * explodeForce;
                Vector3 realExplodeVector3 = new Vector3();
                realExplodeVector3.x = distanceVector3.x * realExplodeForce;
                realExplodeVector3.y = distanceVector3.y * realExplodeForce;
                realExplodeVector3.z = distanceVector3.z * realExplodeForce;
                temp = collider.GetComponent<Transform>().position;
                if (temp.y <= 0.2f) 
                { 
                    temp.y = temp.y+0.2f+(1-distance/4)*0.8f; // if don't have y value, the player can't be moved by addForce()
                }
                collider.GetComponent<Transform>().position = temp;
                collider.GetComponent<Rigidbody>().AddForce(realExplodeVector3);
            }
            else 
            {
                Vector3 realExplodeVector3 = new Vector3(0,explodeForce,0);
                collider.GetComponent<Rigidbody>().AddForce(realExplodeVector3);
            }
            
        }
    }
} 
