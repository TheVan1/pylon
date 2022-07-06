using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bramble : MonoBehaviour
{
    public Transform[] respawn;
    public GameObject Player;
    private Transform currentRespawn ;
    public int IDbramble; 
    // Start is called before the first frame update
    private void Update()
    {
        currentRespawn = respawn[IDbramble];
    }
private void OnCollisionEnter2D(Collision2D collision)
     {
         if(collision.gameObject.tag == "Player")
         {
             Debug.Log("collided2");
             Player.transform.position = currentRespawn.position;
         }
     }
}

