using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class numberOfPlayerInRoom_NM : NetworkBehaviour
{

    public Text showingPlayerNumberPanel;
    GameObject[] obj;

    public int playerInRoom;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    
    void Update()
    {
        playerInRoom = 0;
        obj = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject child in obj)
        {
            if (child.tag == "fakePlayer") playerInRoom++;
        }
        ShowTheNumber(playerInRoom);
        
        
    }

    void ShowTheNumber(int a) 
    {
        if (showingPlayerNumberPanel != null) 
        { 
            showingPlayerNumberPanel.text = a.ToString();
        }
        
    }

}
