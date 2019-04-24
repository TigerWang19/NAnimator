using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CmdRpc : NetworkBehaviour {

    Animator ani;
   
    void Start () {
         ani = GetComponent<Animator>();
        //ani = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        Move();

        // Trigger Walk
        if (Input.GetKeyDown(KeyCode.W))
        {
            CmdWalk();
           // Debug.Log("W!");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            CmdKick();
        }
    }
 
   [ClientRpc]
   void RpcWalk()
    {
        ani.SetTrigger("Walk");  
    }


       [Command]
       void CmdWalk()
    {
        // Trigger Walk
        ani.SetTrigger("Walk");
        RpcWalk();
    }

    [Command]
    void CmdKick()
    {
        ani.SetTrigger("Kick");
        RpcKick();
    }

    [ClientRpc]
    void RpcKick()
    {
        ani.SetTrigger("Kick");
    }


    void Move()
    {     
        // Bool punch

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("Punch", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ani.SetBool("Punch", false);
        }

    }
}
