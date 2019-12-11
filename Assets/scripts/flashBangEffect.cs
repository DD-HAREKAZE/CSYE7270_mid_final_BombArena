using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashBangEffect : MonoBehaviour
{
    public GameObject flashBangPlane;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject);
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "player")
        {
            float flashStartTime = Time.time;
            float flashExpectedEndTime = flashStartTime + 3.5f;
            Vector3 flashPlanePosition=new Vector3(0f,12.5f,-11f);
            GameObject _White=Instantiate(flashBangPlane, flashPlanePosition, Quaternion.identity);
            _White.GetComponent<flashBngPlaneController>().selfDestroyTime = flashExpectedEndTime;
        }
    }
}
