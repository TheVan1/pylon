using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
   public float speed;
   public float distance;
   private bool movingleft = true;
   public Transform groundDetection;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundinfo.collider == false)
        {
            if (movingleft == true){
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingleft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingleft = true;
            }
        }
    }
    
}
