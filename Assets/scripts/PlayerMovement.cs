using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Throwing throwing;
    public HealtController healtController;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
     bool Jump = false;
    bool Crouch = false;
    //Throwing controls variables
    public GameObject ThrownObject;
    int PotsLenght;
    
    bool Throwing = false;

   
    
    void Start()
    {
        throwing.LineCreate();
        throwing.LineActive(false);
        PotsLenght = throwing.Potions.Length;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Throwing = true;
            horizontalMove = 0*runSpeed;

        }
        if (Throwing == false)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
            animator.SetFloat("run", Mathf.Abs(horizontalMove));
            if (Input.GetButtonDown("Jump"))
            {
                Jump = true;
                animator.SetBool("isJumping", true);
            }
            if (Input.GetButtonDown("Crouch"))
            {
                Crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                Crouch = false;
            }
        }
        else if (Throwing == true)
        {
            ThrownObject.SetActive(true); 
            if (Input.GetButtonDown("Crouch"))  
            {
              throwing.potion = throwing.potion-1;
            }
            if (Input.GetButtonDown("Jump"))  
            {
              throwing.potion = throwing.potion+1;
            }
            else if (throwing.potion > PotsLenght-1 || throwing.potion < 0)
            {
              throwing.LineActive(false);
              ThrownObject.SetActive(false);
              throwing.potion = 0;
              Throwing = false;
              
            }
        }
    }
    void FixedUpdate ()
    {
       controller.Move(horizontalMove*Time.fixedDeltaTime, Crouch, Jump);
       Jump = false;
    }
    public void Onlanding()
    {
        animator.SetBool("isJumping", false);
    }
         private void OnCollisionEnter2D(Collision2D collision)
     {
         if(collision.gameObject.tag == "enemy")
         {
             Debug.Log("collided");
             healtController.ChangeHealth(-1);
         }
         
     }

}
