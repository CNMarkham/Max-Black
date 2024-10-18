using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyScreen2Menu : MonoBehaviour
{
    // Start is called before the first frame update
    //Sends you from the Menu to the first scene
    public void ToMenu()
    {
        SceneManager.LoadScene(1);

    }
}
