using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2Scene1 : MonoBehaviour
{
    //Resets all PlayerPrefs
     void Start()
    {
        PlayerPrefs.DeleteAll();
    }
    //Sends you from the Menu to the first scene
    public void LevelSelect()
    {
        SceneManager.LoadScene(7); 

    }
}
