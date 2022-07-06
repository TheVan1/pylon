using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
