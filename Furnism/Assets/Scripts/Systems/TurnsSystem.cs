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

    //Sets the first turn to the players
    #region MyRegion

    #endregion
    void Start()
    {
        Turn = 1;
    }

    //Sets ClassCheck to 1, the turn to 1 (the players turn), and activates all the warriors attack buttons 
    public void DowntimeWarrior()
    {
        ClassCheck = 1;
        Turn = 1;
        TennisBallThrow.SetActive(true);
        SpinAttack.SetActive(true);
        DisrespectfulSlap.SetActive(true);
    }

    //Sets ClassCheck to 2, the turn to 1 (the players turn), and activates all the mages attack buttons
    public void DowntimeMage()
    {
        ClassCheck = 2;
        Turn = 1;
        Fireball.SetActive(true);
        HealSpell.SetActive(true);
        FlyingSwords.SetActive(true);
    }

    //Sets the ClassCheck to 3, the turn to 1 (the players turn), and activates all the archers attack buttons
    public void DowntimeArcher()
    {
        ClassCheck = 3;
        Turn = 1;
        SpiritArrow.SetActive(true);
        FallenArrow.SetActive(true);
        ArrowRain.SetActive(true);
    }

    //Sets the turn to 2 (the bosses turn), turns off all buttons, tells the boss to attack the player, and turns off all the bosses game objects after that
    public void BossTurn()
    {
        Turn = 2;
        UIOff();        
        Invoke("BossAttackPlayer", 2f);
        Invoke("TurnOffGameObjects", 7f);

    }

    //Turns off all the bosses game objects, and checks whos turn it is
    void TurnOffGameObjects()
    {
        TheBossesCanvas.SetActive(false);
        FirstAttackObject.SetActive(false);
        SecondAttackObject.SetActive(false);
        ThirdAttackObject.SetActive(false);
        TurnSet();
    }

    //Makes the boss choose an attack to attack the player with
    void BossAttackPlayer()
    {
        AttackSystem.BossAttack();
    }

    public void TurnSet()

    {
        //If its the players turn, it then checks what class the player chose, and turns off that classes attack buttons, and if its not the players turn, then it first checks what class the player is, then checks for stun, if the player isn't stunned it will make it the players turn and turn all of that classes attack buttons on, however if the player is stunned then it takes away 1 turn of stun
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
                if (AttackSystem.PlayerStunned == 0)
                {
                    Invoke("DowntimeWarrior", 4f);
                } else
                {
                    AttackSystem.PlayerStunned -= 1;
                    if(AttackSystem.PlayerStunned == 0)
                    {
                    }
                }
                
            }
            else if (ClassCheck == 2)
            {
                if (AttackSystem.PlayerStunned == 0)
                {

                    Invoke("DowntimeMage", 4f);
                }
                else
                {
                    AttackSystem.PlayerStunned -= 1;
                    if (AttackSystem.PlayerStunned == 0)
                    {
                    }
                }

            }
            else if (ClassCheck == 3)
            {
                if (AttackSystem.PlayerStunned == 0)
                {
                    Invoke("DowntimeArcher", 4f);
                }
                else
                {
                    AttackSystem.PlayerStunned -= 1;
                    if (AttackSystem.PlayerStunned == 0)
                    {

                    }
                }

            }
        }
    }

    //Turns off all attack buttons no matter what class the player is
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

    //Turns on all attack buttons no matter what class the player is
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
