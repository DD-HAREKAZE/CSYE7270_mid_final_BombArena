using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerConnection : NetworkBehaviour
{
    public GameObject PlayerConnectionPrefab;

    System.Random random = new System.Random(1000);

    // Start is called before the first frame update
    void Start()
    {

        if (isLocalPlayer == false)
        {
            return;
        }

        CmdSpawnMyUnit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Command]
    void CmdSpawnMyUnit() 
    {
        int randomNumber1 = Random.Range(1, 7);
        int randomNumber2 = Random.Range(1, 7);
        Vector3 _playerPosition = new Vector3(randomNumber1, 0.5f, randomNumber2);
        GameObject _playerOnServer = Instantiate(PlayerConnectionPrefab,_playerPosition,Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(_playerOnServer,connectionToClient);

        
        
    }
    

}
