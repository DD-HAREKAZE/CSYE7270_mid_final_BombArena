using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainGameController : MonoBehaviour
{
    // Start is called before the first frame update
    float startTime;
    float t1;//next item to be refreshed


    public GameObject ground;
    public GameObject RGD5Mark;
    public GameObject medicalKitMark;
    public GameObject molotovMark;
    public GameObject flashMark;


    private float groundSpeed;//suoquansudu
    private GameObject itemToRefresh;

    System.Random random = new System.Random(1000);

    void Start()
    {
        groundSpeed = 0.25f;
        startTime = Time.time;
        t1 = startTime + 1.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ground size change
        Vector3 temp = new Vector3();
        temp = ground.GetComponent<Transform>().localScale;
        temp.x = 25 - groundSpeed * (Time.time - startTime);
        temp.z = 25 - groundSpeed * (Time.time - startTime);
        ground.GetComponent<Transform>().localScale =temp;
        //end ground size modify

        //refresh 1 item on ground
        if (Time.time >= t1) 
        {
            //instantiate

            //random a position in arena
            int random_x_posneg = Random.Range(0, 2);
            int random_z_posneg = Random.Range(0, 2);
            if (random_x_posneg == 0) { random_x_posneg--; }
            if (random_z_posneg == 0) { random_z_posneg--; }
            float random_x_value = Random.Range(0, (int)(10-0.08*(Time.time-startTime)));
            float random_z_value = Random.Range(0, (int)(10 - 0.08 * (Time.time - startTime)));
            random_x_value = random_x_value * random_x_posneg;
            random_z_value = random_z_value * random_z_posneg;
            Vector3 instantiate_position=new Vector3();
            instantiate_position.x=random_x_value;
            instantiate_position.z=random_z_value;
            instantiate_position.y=5;
            //end random a position in arena

            //idea: randomly drop some throwed weapons in arena


            //decide what type of item to refresh
            int random_item_type = Random.Range(0, 100);
            if (random_item_type > 79) { itemToRefresh = medicalKitMark; }
            if (random_item_type <40 ) { itemToRefresh = RGD5Mark; }
            if (random_item_type >= 40 && random_item_type <= 59) { itemToRefresh = flashMark; }
            if (random_item_type >= 60 && random_item_type <= 79) { itemToRefresh = molotovMark; }
            //end decide what type of item to refresh

            Instantiate(itemToRefresh, instantiate_position, Quaternion.identity);
            //Debug.Log("item inst! position:X="+RGD5Mark.GetComponent<Transform>().position.x+" Y= "+RGD5Mark.GetComponent<Transform>().position.y+" Z= "+RGD5Mark.GetComponent<Transform>().position.z);

            

            //end instantiate
            t1 = t1 + 0.8f;
        }
        //end refresh item on ground
    }
}
