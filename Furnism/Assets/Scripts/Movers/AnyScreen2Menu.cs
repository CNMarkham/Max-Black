using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyScreen2Menu : MonoBehaviour
{
    //Sends you to the Main Menu
    public void ToMenu()
    {
        SceneManager.LoadScene(0);

    }
}
