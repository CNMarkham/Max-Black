using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour
{
    public SceneMovers sceneMovers;
    // Start is called before the first frame update
    void Start()
    {
        sceneMovers = GetComponent<SceneMovers>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetInt("HighestLevel", 1) >= sceneMovers.LevelNumber)
        {
            GetComponent<Button>().onClick.AddListener(sceneMovers.LoadLevel);
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
