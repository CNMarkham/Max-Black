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
        if (Hp.BossHpInt <= 0 && SecondPhase == false)
        {
            Hp.FinalBossHpSliderUpdate(100);
            SecondPhase = true;
            Change.sprite = Sign;
        } else if(Hp.BossHpInt <= 0 && SecondPhase == true)
        {
            SceneManager.LoadScene(11);
        }
    }
}
