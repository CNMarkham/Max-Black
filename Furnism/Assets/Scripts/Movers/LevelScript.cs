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
        if (PlayerPrefs.GetInt("HighestLevel", 1) >= 4)
        {
            SM.BossLevel.text = "Boss Level";
        }

        if (PlayerPrefs.GetInt("HighestLevel", 1) >= SM.LevelNumber)
        {
            SM.GetComponent<Button>().onClick.AddListener(LoadLevel);
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }   
    
    public void LoadLevel()
    { 
        SceneManager.LoadScene(SM.SceneToLoad);
        PlayerPrefs.SetInt("LevelRespawnAt", SM.LevelToRespawnAt);
    }
}
