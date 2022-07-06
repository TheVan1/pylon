using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeController : MonoBehaviour
{
    public Rigidbody2D[] children;
    public void cut(){
        foreach(Rigidbody2D rb in children){
           rb.bodyType = RigidbodyType2D.Dynamic;
           rb.gameObject.transform.parent = null;
        }
        Destroy(gameObject);
    }

    void Start(){
        foreach(Rigidbody2D rb in children){
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
