using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneMovers : MonoBehaviour
{
    public int SceneToLoad;
    public int LevelToRespawnAt;
    public bool Reset;
    public int HighestLevel;
    public int LevelNumber;
    public TextMeshPro BossLevel;

    private void Start()
    {
        if (Reset == true)
        {
            LevelToRespawnAt = 2;
            PlayerPrefs.SetInt("LevelRespawnAt", SceneToLoad);
        }


    }
    //Load the next scene and set LevelRespawnAt to whatever level it needs to be at for you to respawn at the corresponding level you died at
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneToLoad);
        PlayerPrefs.SetInt("LevelRespawnAt", LevelToRespawnAt);
    }
}
