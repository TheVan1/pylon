using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y,  rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (hasHit== true)
        {
            Destroy(gameObject, 0.5f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        GameObject hit = collision.collider.gameObject;
        if(hit.tag == "enemy" || hit.tag == "rope"){
            try{
                hit.GetComponent<enemypatrol>().dieno();
            }catch{
                hit.GetComponent<ropeController>().cut();
            }
        }
        
    }
}
