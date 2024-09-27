using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchDie : MonoBehaviour
{
    public GameObject Player;

    //When you die you get sent to the death screen
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(5);
    }

    //Sends you back to the level you died at so you can play again
    public void PlayAgain()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelRespawnAt"));
    }
}
