using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovers : MonoBehaviour
{
    public int SceneToLoad;
    public int LevelToRespawnAt;
    public bool Reset;
    public PlayerMovement PMovement;

    private void Start()
    {
        if(Reset == true)
        {
            LevelToRespawnAt = 2;
            PlayerPrefs.SetInt("LevelRespawnAt", LevelToRespawnAt);
        }
    }
    //Load the next scene and set LevelRespawnAt to whatever level it needs to be at for you to respawn at the corresponding level you died at
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneToLoad);
        PlayerPrefs.SetInt("LevelRespawnAt", LevelToRespawnAt);

        
    }
}
