using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneMovers : MonoBehaviour
{
    [Header("Ints")]
    public int SceneToLoad;
    public int LevelToRespawnAt;
    public int HighestLevel;
    public int LevelNumber;

    [Header("Bools")]
    public bool Reset;

    [Header("Text")]
    public TextMeshPro BossLevel;

    //When reset is active you will respawn and start at Level 1
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
