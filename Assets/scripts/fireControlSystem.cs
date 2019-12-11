using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireControlSystem : MonoBehaviour
{
    private int selectedWeapon;//1=RGD5 2=flashBang 3=molotov

    //private GameObject selectedWeapon;
    public GameObject RGD5;
    public GameObject flashBang;
    public GameObject molotov;
    private int RGD5amount;
    private int flashBangAmount;
    private int molotovAmount;

    public GameObject RGD5UIIcon;
    public GameObject flashBangUIIcon;
    public GameObject molotovUIIcon;
    public GameObject selectedWeaponUIIcon;

    private float normalThrowForceTimes=300f;
    private float reducedThrowForceTimes = 100f;

    private float temp;
    // Start is called before the first frame update
    void Start()
    {
        selectedWeapon = 1;// use RGD5 as default
        RGD5amount = this.gameObject.GetComponent<playerInventory>().RGD5Amount;
        flashBangAmount = this.gameObject.GetComponent<playerInventory>().flashAmount;
        molotovAmount = this.gameObject.GetComponent<playerInventory>().molotovAmount;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //weapon selection
        if (Input.GetKey(KeyCode.Alpha1) == true) { selectedWeapon = 1;  }
        if (Input.GetKey(KeyCode.Alpha2) == true) { selectedWeapon = 2;  }
        if (Input.GetKey(KeyCode.Alpha3) == true) { selectedWeapon = 3;  }

        //refresh UI
        if (selectedWeapon == 1) 
        {
            Vector2 selectedWeaponUIIconPosition = new Vector2();
            selectedWeaponUIIconPosition = RGD5UIIcon.GetComponent<Transform>().position;
            selectedWeaponUIIcon.GetComponent<Transform>().position = selectedWeaponUIIconPosition;
        }
        if (selectedWeapon == 2)
        {
            Vector2 selectedWeaponUIIconPosition = new Vector2();
            selectedWeaponUIIconPosition = flashBangUIIcon.GetComponent<Transform>().position;
            selectedWeaponUIIcon.GetComponent<Transform>().position = selectedWeaponUIIconPosition;
        }
        if (selectedWeapon == 3)
        {
            Vector2 selectedWeaponUIIconPosition = new Vector2();
            selectedWeaponUIIconPosition = molotovUIIcon.GetComponent<Transform>().position;
            selectedWeaponUIIcon.GetComponent<Transform>().position = selectedWeaponUIIconPosition;
        }

        //fire1
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 throwPosition = new Vector3();
            throwPosition = transform.position;
            throwPosition.y = throwPosition.y + 1.8f;

            //instantiate a g
            
            if (selectedWeapon == 1 && gameObject.GetComponent<playerInventory>().RGD5Amount>0) 
            {
                GameObject _G = Instantiate(RGD5, throwPosition, Quaternion.identity);
                gameObject.GetComponent<playerInventory>().RGD5Amount--;

                Vector3 throwForce = new Vector3();
                throwForce = launchForce(normalThrowForceTimes);

                _G.GetComponent<Rigidbody>().AddForce(throwForce);
            }

            if (selectedWeapon == 2 && gameObject.GetComponent<playerInventory>().flashAmount > 0)
            {
                GameObject _G = Instantiate(flashBang, throwPosition, Quaternion.identity);
                gameObject.GetComponent<playerInventory>().flashAmount--;

                Vector3 throwForce = new Vector3();
                throwForce = launchForce(normalThrowForceTimes);

                _G.GetComponent<Rigidbody>().AddForce(throwForce);
            }

            if (selectedWeapon == 3 && gameObject.GetComponent<playerInventory>().molotovAmount > 0) 
            {
                GameObject _G = Instantiate(molotov, throwPosition, Quaternion.identity);
                gameObject.GetComponent<playerInventory>().molotovAmount--;

                Vector3 throwForce = new Vector3();
                throwForce = launchForce(normalThrowForceTimes);

                _G.GetComponent<Rigidbody>().AddForce(throwForce);
            }

        }
        //end fire1


        //fire2
        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 throwPosition = new Vector3();
            throwPosition = transform.position;
            throwPosition.y = throwPosition.y + 1.8f;

            //instantiate a g

            if (selectedWeapon == 1 && gameObject.GetComponent<playerInventory>().RGD5Amount > 0)
            {
                GameObject _G = Instantiate(RGD5, throwPosition, Quaternion.identity);
                gameObject.GetComponent<playerInventory>().RGD5Amount--;

                Vector3 throwForce = new Vector3();
                throwForce = launchForce(reducedThrowForceTimes);

                _G.GetComponent<Rigidbody>().AddForce(throwForce);
            }

            if (selectedWeapon == 2 && gameObject.GetComponent<playerInventory>().flashAmount > 0)
            {
                GameObject _G = Instantiate(flashBang, throwPosition, Quaternion.identity);
                gameObject.GetComponent<playerInventory>().flashAmount--;

                Vector3 throwForce = new Vector3();
                throwForce = launchForce(reducedThrowForceTimes);

                _G.GetComponent<Rigidbody>().AddForce(throwForce);
            }

            if (selectedWeapon == 3 && gameObject.GetComponent<playerInventory>().molotovAmount > 0)
            {
                GameObject _G = Instantiate(molotov, throwPosition, Quaternion.identity);
                gameObject.GetComponent<playerInventory>().molotovAmount--;

                Vector3 throwForce = new Vector3();
                throwForce = launchForce(reducedThrowForceTimes);

                _G.GetComponent<Rigidbody>().AddForce(throwForce);
            }

        }
        //end fire2





    }


    private Vector3 launchForce(float a) 
    {
        Vector3 throwForce = new Vector3();
        throwForce = gameObject.transform.forward;
        temp = Mathf.Sqrt(throwForce.x * throwForce.x + throwForce.z * throwForce.z);
        float realThrowForce_x = throwForce.x / temp;
        float realThrowForce_y = 0f;
        float realThrowForce_z = throwForce.z / temp;
        float humanAim_x = realThrowForce_x;
        float humanAim_y = temp;
        float humanAim_z = realThrowForce_z;
        temp = Mathf.Sqrt(humanAim_x * humanAim_x + humanAim_y * humanAim_y + humanAim_z * humanAim_z);
        realThrowForce_x = humanAim_x / temp;
        realThrowForce_y = humanAim_y / temp;
        realThrowForce_z = humanAim_z / temp;



        throwForce.x = realThrowForce_x * a;
        throwForce.y = realThrowForce_y * a;
        throwForce.z = realThrowForce_z * a;

        return throwForce;
    }




    
}
