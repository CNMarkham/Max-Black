using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnsSystem : MonoBehaviour
{
    [Header("Other Script References")]
    public AttacksSystem AttackSystem;
    
    [Header("Ints")]
    public int Turn;
    public int ClassCheck;
    
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
    
    [Header("Boss GameObjects")]
    public GameObject TheBoss;
    public GameObject TheBossesCanvas;
    public GameObject FirstAttackObject;
    public GameObject SecondAttackObject;
    public GameObject ThirdAttackObject;

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

    public void BossTurn()
    {
        Turn = 2;
        UIOff();        
        Invoke("BossAttackPlayer", 2f);
        Invoke("TurnOffGameObjects", 7f);

    }

    void TurnOffGameObjects()
    {
        TheBossesCanvas.SetActive(false);
        FirstAttackObject.SetActive(false);
        SecondAttackObject.SetActive(false);
        ThirdAttackObject.SetActive(false);
        TurnSet();
    }

    void BossAttackPlayer()
    {
        AttackSystem.BossAttack();
    }
    public void TurnSet()

    {
        if (Turn == 1)
        {
            if (ClassCheck == 1)
            {
                BossTurn();
                TennisBallThrow.SetActive(false);
                SpinAttack.SetActive(false);
                DisrespectfulSlap.SetActive(false);
            }
            else if (ClassCheck == 2)
            {
                BossTurn();
                Fireball.SetActive(false);
                HealSpell.SetActive(false);
                FlyingSwords.SetActive(false);
            }
            else
            {
                BossTurn();
                SpiritArrow.SetActive(false);
                FallenArrow.SetActive(false);
                ArrowRain.SetActive(false);
            }
        }
        else
        {
            if (ClassCheck == 1)
            {
                Invoke("DowntimeWarrior", 4f);
            }
            else if (ClassCheck == 2)
            {
                Invoke("DowntimeMage", 4f);
            }
            else if (ClassCheck == 3)
            {
                Invoke("DowntimeArcher", 4f);
            }
        }
    }

    public void UIOff()
    {
        TennisBallThrow.SetActive(false);
        SpinAttack.SetActive(false);
        DisrespectfulSlap.SetActive(false);
        
        Fireball.SetActive(false);
        HealSpell.SetActive(false);
        FlyingSwords.SetActive(false);
        
        SpiritArrow.SetActive(false);
        FallenArrow.SetActive(false);
        ArrowRain.SetActive(false);
    }

    public void UIOn()
    {
        if (ClassCheck == 1)
        {
            TennisBallThrow.SetActive(true);
            SpinAttack.SetActive(true);
            DisrespectfulSlap.SetActive(true);
        }
        else if (ClassCheck == 2)
        {
            Fireball.SetActive(true);
            HealSpell.SetActive(true);
            FlyingSwords.SetActive(true);
        }
        else if (ClassCheck == 3)
        {
            SpiritArrow.SetActive(true);
            FallenArrow.SetActive(true);
            ArrowRain.SetActive(true);
        }
    }

}
