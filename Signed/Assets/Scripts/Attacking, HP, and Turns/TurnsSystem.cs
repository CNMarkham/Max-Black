using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnsSystem : MonoBehaviour
{
    [Header("Other Script References")]
    
    public int Turn;
    public int ClassCheck;
    public BossAttacking BossAttacking;
    
    [Header("Warrior Vars")]
    public GameObject TennisBallThrow;
    public GameObject SpinAttack;
    public GameObject DisrespectfulSlap;

    [Header("Mage Vars")]
    public GameObject Fireball;
    public GameObject HealSpell;
    public GameObject FlyingSwords;

    [Header("Archer Vars")]
    public GameObject SpiritArrow;
    public GameObject FallenArrow;
    public GameObject ArrowRain;

    #region MyRegion

    #endregion
    void Start()
    {
        Turn = 1;
    }

    public void DowntimeWarrior()
    {
        ClassCheck = 1;
        Turn = 1;
        TennisBallThrow.SetActive(true);
        SpinAttack.SetActive(true);
        DisrespectfulSlap.SetActive(true);
    }

    public void DowntimeMage()
    {
        ClassCheck = 2;
        Turn = 1;
        Fireball.SetActive(true);
        HealSpell.SetActive(true);
        FlyingSwords.SetActive(true);
    }

    public void DowntimeArcher()
    {
        ClassCheck = 3;
        Turn = 1;
        SpiritArrow.SetActive(true);
        FallenArrow.SetActive(true);
        ArrowRain.SetActive(true);
    }

    void BossTurn()
    {
        Turn = 2;
        Invoke("RandomAttack", 1.5f);
        CheckTurn();
    }
    void RandomAttack()
    {
        BossAttacking.RandomizedAttack();
    }
    public void CheckTurn()
    {
        if (Turn == 1)
        {
            if (ClassCheck == 1)
            {
                BossTurn();
                Fireball.SetActive(false);
                HealSpell.SetActive(false);
                FlyingSwords.SetActive(false);
            } else if(ClassCheck == 2)
            {
                BossTurn();
                Fireball.SetActive(false);
                HealSpell.SetActive(false);
                FlyingSwords.SetActive(false);
            } else
            {
                BossTurn();
                SpiritArrow.SetActive(false);
                FallenArrow.SetActive(false);
                ArrowRain.SetActive(false);
            }
        } else
        {
            if(ClassCheck == 1)
            {
                Invoke("DowntimeWarrior", 4f);
            }  else if(ClassCheck == 2)
            {
                Invoke("DowntimeMage", 4f);
            } else
            {
                Invoke("DowntimeArcher", 4f);
            }         
        }
    }
}
