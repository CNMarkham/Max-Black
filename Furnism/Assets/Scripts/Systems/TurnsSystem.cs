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


    //Sets the first turn to the players.
    #region MyRegion

    #endregion
    void Start()
    {
        Turn = 1;
    }

    //When StrongSlap is on cooldown make its button uninteractable.
    private void Update()
    {
        AttackSystem.AttackDisabledText.text = (AttackSystem.AttackDisabled.ToString());
        if(AttackSystem.AttackDisabled >= 1)
        {
            StrongSlap.GetComponent<Button>().interactable = false;
        }
    }

    //Sets it to the Players turn, and activates all the Warriors attack buttons.
    public void DowntimeWarrior()
    {
        ClassCheck = 1;
        Turn = 1;
        BallThrow.SetActive(true);
        SpinSmack.SetActive(true);
        StrongSlap.SetActive(true);
    }

    //Sets it to the Players turn, and activates all the Mages attack buttons.
    public void DowntimeMage()
    {
        ClassCheck = 2;
        Turn = 1;
        Fireball.SetActive(true);
        HealSpell.SetActive(true);
        TwoSwords.SetActive(true);
    }

    //Sets it to the Players turn, and activates all the Archers attack buttons. 
    public void DowntimeArcher()
    {
        ClassCheck = 3;
        Turn = 1;
        SpiritArrow.SetActive(true);
        FallenArrow.SetActive(true);
        ArrowRain.SetActive(true);
    }

    //Sets it to the Bosses turn, turns off all buttons, and tells the Boss to attack the Player.
    public void BossTurn()
    {
        Turn = 2;
        UIOff();
        Invoke("BossAttackPlayer", 2f);
        Invoke("TurnOffGameObjects", 6f);
    }

    //Cuts off the waiting time for the Players buttons to reappear as the Bosses turn will be skipped due to it being stunned.
    public void BossTurnStunned()
    {
        Turn = 2;
        UIOff();
        Invoke("BossAttackPlayer", 3f);
        Turn = 2;
        TurnSet();
    }

    //Same as BossTurn but takes longer to give the Player back its controls.
    public void BossTurnExtended()
    {
        Turn = 2;
        UIOff();
        Invoke("BossAttackPlayer", 2f);
        Invoke("TurnOffGameObjects", 8f);
    }

    //Same as BossTurnExtended but takes even longer to give the Player back its controls.
    public void BossTurnMoreExtended()
    {
        Turn = 2;
        UIOff();
        Invoke("BossAttackPlayer", 2f);
        Invoke("TurnOffGameObjects", 10f);
    }


    //Turns off all the bosses game objects, and checks whos turn it is.
    void TurnOffGameObjects()
    {
        TheBossesCanvas.SetActive(false);
        FirstAttackObject.SetActive(false);
        SecondAttackObject.SetActive(false);
        ThirdAttackObject.SetActive(false);
        Turn = 2;
        TurnSet();
    }

    //Makes the boss choose an attack to attack the player with.
    void BossAttackPlayer()
    {
        AttackSystem.BossAttack();
    }

    public void TurnSet()

    {
        //Checks whose turn it is if it's it checks if the Player is stunned or not, if they are make it the bosses turn. And if it isn't the Players turn it continues the Bosses.
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

    //If an attack is disabled makes the text tell you how many turns there are until it can be used once more.s
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
