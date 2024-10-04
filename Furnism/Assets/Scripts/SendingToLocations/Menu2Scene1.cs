using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2Scene1 : MonoBehaviour
{

     void Start()
    {
        PlayerPrefs.DeleteAll();
    }
    //Sends you from the Menu to the first scene
    public void ToScene1()
    {
        PlayerPrefs.SetInt("LevelRespawnAt", 2);
        SceneManager.LoadScene(1);

    }
}
