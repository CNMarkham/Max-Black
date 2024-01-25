using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPhase2 : MonoBehaviour
{
    public HPSystem HP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP.BossHpInt <= 0)
        {
            HP.BossHpInt = 0;
            SceneManager.LoadScene("Real Scene 2");
        }
    }
}
