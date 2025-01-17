using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public SceneMovers SM;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("HighestLevel"));
        if(PlayerPrefs.GetInt("HighestLevel") <= 0)
        {
            PlayerPrefs.SetInt("HighestLevel", 1);
        }
        if (PlayerPrefs.GetInt("HighestLevel") >= 4)
        {
            SM.BossLevel.text = "Boss Level";
        }

        if (PlayerPrefs.GetInt("HighestLevel") >= SM.LevelNumber)
        {
            SM.GetComponent<Button>().onClick.AddListener(LoadLevel);
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }
    
    //Loads the last level you were at and makes sure that the level you will respawn at next time is the level your on
    public void LoadLevel()
    { 
        SceneManager.LoadScene(SM.SceneToLoad);
        PlayerPrefs.SetInt("LevelRespawnAt", SM.LevelToRespawnAt);
    }
}
