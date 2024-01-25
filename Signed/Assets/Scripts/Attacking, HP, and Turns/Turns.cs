using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour
{
    public int Turn;
    public GameObject RegularAttack;
    public GameObject Run;
    public GameObject Items;
    public GameObject InsultAttack;
    public BossAttacking BossAttacking;
    void Start()
    {
        Turn = 1;
    }
    void Downtime()
    {
        Turn = 1;
        RegularAttack.SetActive(true);
        Run.SetActive(true);
        Items.SetActive(true);
        InsultAttack.SetActive(true);
    }
    void BossTurn()
    {
        Turn = 2;
        Invoke("QueueARandomAttack", 1.5f);
        CheckTurn();
    }
    void QueueARandomAttack()
    {
        BossAttacking.RandomizedAttack();
    }
    public void CheckTurn()
    {
        if(Turn == 1)
        {
            BossTurn();
            RegularAttack.SetActive(false);
            Run.SetActive(false);
            Items.SetActive(false);
            InsultAttack.SetActive(false);
        } else
        {
            Invoke("Downtime", 4f);
            
        }
    }
}
