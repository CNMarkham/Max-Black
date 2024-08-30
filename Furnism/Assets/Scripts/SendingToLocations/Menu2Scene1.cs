using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2Scene1 : MonoBehaviour
{

    //Sends you from the Menu to the first scene
    public void ToScene1()
    {
        SceneManager.LoadScene(1);
    }
}
