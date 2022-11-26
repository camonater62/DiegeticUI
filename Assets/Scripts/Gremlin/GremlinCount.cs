using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinCount : MonoBehaviour
{
    public FinaleManagerScript finale;
    public GameObject Count;
    public GameObject Count1;
    public GameObject Count2;
    public GameObject Count3;
    public GameObject Count4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(finale.musicCount);
        if (finale.musicCount == 1)
        {
            Count.SetActive(true);
        }
        if (finale.musicCount == 2)
        {
            Count1.SetActive(true);
        }
        if (finale.musicCount == 3)
        {
            Count2.SetActive(true);
        }
        if (finale.musicCount == 4)
        {
            Count3.SetActive(true);
        }
        if (finale.musicCount == 5)
        {
            Count4.SetActive(true);
        }

        
    }
}
