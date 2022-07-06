using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawndetect : MonoBehaviour
{
    public int ID;
    public bramble bramble;
private void OnTriggerEnter2D(Collider2D collision)
     {
         if(collision.gameObject.tag == "Player")
         {
             bramble.IDbramble = ID;
         }
     }
}
