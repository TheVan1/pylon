using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtController : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health;
    public int NOfHearts;
    public UnityEngine.UI.Image[] hearts;
    public Sprite Fheart;
    public Sprite Eheart;
    public bool IsAvailable = true;
     public float HealthCooldown = 1.0f;
 // Update is called once per frame
    void Update()
    {
        if (Health == 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        //heart container logic
        if (Health > NOfHearts)
        {
            Health = NOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Health)
            {
                hearts[i].overrideSprite = Fheart;
            }
            else
            {
                hearts[i].overrideSprite = Eheart;
            }
            if (i < NOfHearts)
            {
                hearts[i].enabled = true;
            }
            else{
                hearts[i].enabled = false;
            }
        }
    }

    //health manipulation methods
    public void ChangeHearts(int heart)
    {
        NOfHearts += heart;
    }
     public void ChangeHealth(int health)
    {
        if (IsAvailable == false)
         {
             return;
         }
        Health += health;
                 
        StartCoroutine(StartCooldown());
     }
     
     public IEnumerator StartCooldown()
     {
         IsAvailable = false;
         yield return new WaitForSeconds(HealthCooldown);
         IsAvailable = true;
    }


}