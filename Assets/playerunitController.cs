using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerunitController : NetworkBehaviour
{

    public int ReadyOrNotToken;
    // Start is called before the first frame update
    void Start()
    {
        ReadyOrNotToken = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
