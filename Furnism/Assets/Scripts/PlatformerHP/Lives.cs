using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public static Lives MainLives;
    public int Hearts;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    //Start with three hearts, make sure all the heart gameObjects are active, and makes this script MainLives
    void Start()
    {
        Hearts = 3;
        Heart1.SetActive(true);
        Heart2.SetActive(true);
        Heart3.SetActive(true);
        MainLives = this;
    }


    //Turns off the heart gameObjects when you have that many hearts
    void Update()
    {
        if(Hearts == 2)
        {
            Heart3.SetActive(false);
        } else if (Hearts == 1)
        {
            Heart2.SetActive(false);
        }
    }
}
