using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBossDeath : MonoBehaviour
{
    public HPSystem Hp;
    public bool SecondPhase;
    public SpriteRenderer Change;
    public Sprite Sign;
    // Start is called before the first frame update
    void Start()
    {
        SecondPhase = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp.BossHPNum <= 0 && SecondPhase == false)
        {
            SecondPhase = true;
            Change.sprite = Sign;
        } else if(Hp.BossHPNum <= 0 && SecondPhase == true)
        {
            SceneManager.LoadScene(11);
        }
    }
}
