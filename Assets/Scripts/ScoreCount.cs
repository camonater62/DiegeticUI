using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public ScoreManager scoremanager;
    public GameObject Count;
    public GameObject Count1;
    public GameObject Count2;
    public GameObject Count3;
    public GameObject Count4;
    public GameObject Count5;
    public GameObject Count6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (scoremanager.score == 1)
        {
            Count.SetActive(true);
        }
        if (scoremanager.score == 2)
        {
            Count1.SetActive(true);
        }
        if (scoremanager.score == 3)
        {
            Count2.SetActive(true);
        }
        if (scoremanager.score == 4)
        {
            Count3.SetActive(true);
        }
        if (scoremanager.score == 5)
        {
            Count4.SetActive(true);
        }
        if (scoremanager.score == 6)
        {
            Count5.SetActive(true);
        }
        if (scoremanager.score == 7)
        {
            Count6.SetActive(true);
        }
        
    }
}
