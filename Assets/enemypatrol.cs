using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemypatrol : MonoBehaviour
{    
    public Transform t1;
    public Transform t2;
    void Start()
    {
        if(t1.position.x <= t2.position.x){
            Transform temp = t1;
            t1 = t2;
            t2 = temp;
        }       //makes it so that t1 is always larger than t2
    }

    public float direction = 1f;
    public float moveSpeed = 10f;
    public bool facingLeft = true;
    void Update()
    {
        transform.Translate(new Vector2(moveSpeed * direction * Time.deltaTime, 0));
        if(transform.position.x >= t1.position.x || transform.position.x <= t2.position.x){
            direction = Mathf.Sign(t2.position.x - transform.position.x);
            transform.localScale = new Vector2(-direction, 1);
        }

    }

    public void dieno(){ //hehe, get it?
        Destroy(gameObject);
    }

}
