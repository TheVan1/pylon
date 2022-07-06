using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionIndicator : MonoBehaviour
{
    public Throwing throwing;
    public Image[] PtIndicators;
    public Color Seltint;
    public Color Basecolor;
    public int ptnum; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    ptnum = throwing.potion;
        if (ptnum == 0)
        {
            PtIndicators[ptnum].color = Seltint;
            PtIndicators[3].color = Basecolor;
            PtIndicators[ptnum+1].color = Basecolor;
        }
        else if (ptnum > 0 && ptnum < 3)
        {
            PtIndicators[ptnum].color = Seltint;
            PtIndicators[ptnum-1].color = Basecolor;
            PtIndicators[ptnum+1].color = Basecolor;
        }
        else if (ptnum == 3)
        {
            PtIndicators[ptnum].color = Seltint;
            PtIndicators[ptnum-1].color = Basecolor;
        }
    }
}
