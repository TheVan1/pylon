using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    public GameObject[] Potions;
    public int potion;
    public float launchForce;
    public Transform shootPoint;
    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    Vector2 direction;
    private void OnEnable()
    {
        LineActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 armPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - armPosition;
        transform.right = direction;
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        for (int i = 0 ; i < numberOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }

    void Shoot()
    {
        GameObject newPotion = Instantiate(Potions[potion], shootPoint.position, shootPoint.rotation);
        newPotion.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shootPoint.position + (direction.normalized * launchForce * t) + 0.5f *Physics2D.gravity*(t*t);
        return position;
    }
    //These methods handle the points
   public void LineActive(bool active)
    {
        if(active == false)
        {
                for (int i = 0 ; i < numberOfPoints; i++)
            {
                points[i].SetActive(false);
            }
        }
        else if(active == true)
        {
               for (int i = 0 ; i < numberOfPoints; i++)
            {
                points[i].SetActive(true);
            }
        }
    }
    public void LineCreate()
    {
     points = new GameObject[numberOfPoints];
        for (int i = 0 ; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shootPoint.position, Quaternion.identity);
        }
    }
}
