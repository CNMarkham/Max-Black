using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IfPlayerDead : MonoBehaviour
{
    public HP Hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp.PlayerHPButReal <= 0)
        {
            SceneManager.LoadScene(10);
        }
    }
}
