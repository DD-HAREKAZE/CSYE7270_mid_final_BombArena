using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Networking;

public class startGameButtonController : NetworkBehaviour
{

    GameObject[] obj;
    public GameObject NM;

    int ReadyOrNot;
    int temp=0;
    // Start is called before the first frame update
    void Start()
    {
        ReadyOrNot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        temp = 0;
        obj = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject child in obj) 
        {
            if (child.tag == "fakePlayer") 
            {
                if (child.GetComponent<playerunitController>().ReadyOrNotToken == 1) 
                {
                    temp++;
                }
            }
        }
        if (temp == NM.GetComponent<numberOfPlayerInRoom_NM>().playerInRoom && temp!=0) 
        {
            NetworkManager.singleton.ServerChangeScene("SampleScene");
        }
    }

    [Command]
    public void CmdStartGame()
    {
        this.gameObject.GetComponent<Image>().color = Color.green;
        obj = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject child in obj)
        {
            if (child.tag == "fakePlayer")
            {
                if (hasAuthority) 
                {
                    child.GetComponent<playerunitController>().ReadyOrNotToken = 1;
                }
            }
        }
        //SceneManager.LoadScene("SampleScene");   
    }
        
}
