using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    public SceneMovers SM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("HighestLevel", 1) >= 4)
        {
            SM.BossLevel.text = "Boss Level";
        }

        if (PlayerPrefs.GetInt("HighestLevel", 1) >= SM.LevelNumber)
        {
            SM.GetComponent<Button>().onClick.AddListener(SM.LoadLevel);
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
