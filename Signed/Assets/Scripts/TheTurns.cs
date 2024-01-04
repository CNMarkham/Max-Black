using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheTurns : MonoBehaviour
{
    public int Turn;
    public GameObject Touch;
    public GameObject Walk;
    public GameObject Bag;
    public GameObject Surprise;
    public TheBossAttack TheBossAttack;
    // Start is called before the first frame update
    void Start()
    {
        Turn = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Downtime()
    {
        Turn = 1;
        Touch.SetActive(true);
        Walk.SetActive(true);
        Bag.SetActive(true);
        Surprise.SetActive(true);
    }

    public void EnemyTurn()
    {
        Turn = 2;
        Invoke("Soemthing", 1.5f);
        CheckTurn();
    }

    void Soemthing()
    {
        TheBossAttack.BossRandomAttack();
    }

    public void CheckTurn()
    {
        if(Turn == 1)
        {
            EnemyTurn();
            Touch.SetActive(false);
            Walk.SetActive(false);
            Bag.SetActive(false);
            Surprise.SetActive(false);
        } else
        {
            Invoke("Downtime", 4f);
            
        }
    }
}
