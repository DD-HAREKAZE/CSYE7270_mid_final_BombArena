using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHP : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP;
    public Image foreHPBar;
    void Start()
    {
        HP = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreHPBar.fillAmount = HP / 100;
        if (HP <= 0) 
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("playerDied");
        }
    }

    public void loseHP(float a) 
    {
        HP = HP - a;
    }

    public void recoverHP(float a)
    {
        if (HP + a < 100) 
        {
            HP = HP + a;
        } 
        else 
        { 
            HP = 100; 
        }
    }
}
