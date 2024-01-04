using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenderL2 : MonoBehaviour
{
    public HP HP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP.EnemyHPButReal <= 0)
        {
            HP.EnemyHPButReal = 0;
            SceneManager.LoadScene("1");
        }
    }
}
