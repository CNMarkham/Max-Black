using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnsSystem : MonoBehaviour
{
    [Header("Other Script References")]
    public AttacksSystem AttackSystem;
    
    [Header("Ints")]
    public int Turn;
    public int ClassCheck;
    
    [Header("Warrior Vars")]
    public GameObject BallThrow;
    public GameObject SpinSmack;
    public GameObject StrongSlap;

    [Header("Mage Vars")]
    public GameObject Fireball;
    public GameObject HealSpell;
    public GameObject TwoSwords;

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

    private void Update()
    {
        AttackSystem.AttackDisabledText.text = (AttackSystem.AttackDisabled.ToString());
        if(AttackSystem.AttackDisabled >= 1)
        {
            StrongSlap.GetComponent<Button>().interactable = false;
        }
    }

    //Sets ClassCheck to 1, the turn to 1 (the players turn), and activates all the warriors attack buttons 
    public void DowntimeWarrior()
    {
        ClassCheck = 1;
        Turn = 1;
        BallThrow.SetActive(true);
        SpinSmack.SetActive(true);
        StrongSlap.SetActive(true);
    }

    //Sets ClassCheck to 2, the turn to 1 (the players turn), and activates all the mages attack buttons
    public void DowntimeMage()
    {
        ClassCheck = 2;
        Turn = 1;
        Fireball.SetActive(true);
        HealSpell.SetActive(true);
        TwoSwords.SetActive(true);
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
        Invoke("TurnOffGameObjects", 6f);
    }

    public void BossTurnStunned()
    {
        Turn = 2;
        UIOff();
        Invoke("BossAttackPlayer", 3f);
        Turn = 2;
        TurnSet();
    }

    public void BossTurnExtended()
    {
        Turn = 2;
        UIOff();
        Invoke("BossAttackPlayer", 2f);
        Invoke("TurnOffGameObjects", 8f);
    }

    public void BossTurnHeal()
    {
        Turn = 2;
        UIOff();
        Invoke("BossAttackPlayer", 2f);
        Invoke("TurnOffGameObjects", 8f);
    }


    //Turns off all the bosses game objects, and checks whos turn it is
    void TurnOffGameObjects()
    {
        TheBossesCanvas.SetActive(false);
        FirstAttackObject.SetActive(false);
        SecondAttackObject.SetActive(false);
        ThirdAttackObject.SetActive(false);
        Turn = 2;
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
                BallThrow.SetActive(false);
                SpinSmack.SetActive(false);
                StrongSlap.SetActive(false);
            }
            else if (ClassCheck == 2)
            {
                BossTurn();
                Fireball.SetActive(false);
                HealSpell.SetActive(false);
                TwoSwords.SetActive(false);
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
                if (AttackSystem.PlayerStunned == false)
                {
                    Invoke("DowntimeWarrior", 4f);
                } else
                {
                    AttackSystem.PlayerStunned = false;
                    BossTurn();
                }
                
            }
            else if (ClassCheck == 2)
            {
                if (AttackSystem.PlayerStunned == false)
                {

                    Invoke("DowntimeMage", 4f);
                }
                else
                {
                    AttackSystem.PlayerStunned = false;
                    BossTurn();
                }

            }
            else if (ClassCheck == 3)
            {
                if (AttackSystem.PlayerStunned == false)
                {
                    Invoke("DowntimeArcher", 4f);
                }
                else
                {
                    AttackSystem.PlayerStunned = false;
                    BossTurn();
                }

            }
        }
    }

    public void CheckDisabledAttack()
    {
        if (AttackSystem.AttackDisabled >= 1 && AttackSystem.AttackDisabled <= 2)
        {
            AttackSystem.AttackDisabledText.text = (AttackSystem.AttackDisabled.ToString());
            AttackSystem.AttackDisabled -= 1;
            StrongSlap.GetComponent<Button>().interactable = false;
        }
        else
        {
            AttackSystem.AttackDisabledText.text = ("");
            StrongSlap.GetComponent<Button>().interactable = true;
        }
    }

    //Turns off all attack buttons no matter what class the player is
    public void UIOff()
    {
        BallThrow.SetActive(false);
        SpinSmack.SetActive(false);
        StrongSlap.SetActive(false);
        
        Fireball.SetActive(false);
        HealSpell.SetActive(false);
        TwoSwords.SetActive(false);
        
        SpiritArrow.SetActive(false);
        FallenArrow.SetActive(false);
        ArrowRain.SetActive(false);
    }

    //Turns on all attack buttons no matter what class the player is
    public void UIOn()
    {
        if (ClassCheck == 1)
        {
            BallThrow.SetActive(true);
            SpinSmack.SetActive(true);
            StrongSlap.SetActive(true);
        }
        else if (ClassCheck == 2)
        {
            Fireball.SetActive(true);
            HealSpell.SetActive(true);
            TwoSwords.SetActive(true);
        }
        else if (ClassCheck == 3)
        {
            SpiritArrow.SetActive(true);
            FallenArrow.SetActive(true);
            ArrowRain.SetActive(true);
        }
    }

}
