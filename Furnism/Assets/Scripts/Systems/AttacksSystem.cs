using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttacksSystem : MonoBehaviour
{
    [Header("Other Script References")]
    public HPSystem HPSystem;
    public TurnsSystem TurnsSystem;

    [Header("Boss Vars")]
    public int BossCheck;
    public int Diceroll;
    public bool BossBuffed; 

    [Header("Player Vars")]
    public int DMGRoll;
    public int BossPierced;
    public int PierceDMG; 
    public bool PlayerBuffed;

    [Header("GameObjects")]
    public GameObject TheBoss;
    public GameObject Warrior;
    public GameObject Mage;
    public GameObject Archer;

    [Header("Attack Vars")]
    public int PlayerStunned;
    public int BossStunned;

    [Header("Audio")]
    public AudioSource BDamage;
    public AudioSource PDamage;

    //Turn the buttons off, trigger the Tennis Ball Throw animation, roll for damage, do that damage, tell the system its now the bosses turn, and trigger the sound effects
    public void TennisBallThrow()
    {
        TurnsSystem.UIOff();
        Warrior.GetComponent<Animator>().SetTrigger("1stAttack");
        int DMGRoll = Random.Range(7, 11);
        HPSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }

    //Turn the buttons off, trigger the Spin Attack animation, roll for damage, do that damage, add defense stats, tell the system its now the bosses turn, and trigger the sound effects
    public void SpinAttack()
    {
        TurnsSystem.UIOff();
        Warrior.GetComponent<Animator>().SetTrigger("2ndAttack");
        int DMGRoll = Random.Range(6, 9);
        HPSystem.DMGTakenBoss = DMGRoll;
        HPSystem.PlayerDef += 1;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }

    //Turn the buttons off, trigger the Disrespectful Slap animation, roll for damage, do that damage, add defense stats, tell the system its now the bosses turn, and trigger the sound effects
    public void DisrespectfulSlap()
    {
        TurnsSystem.UIOff();
        Warrior.GetComponent<Animator>().SetTrigger("3rdAttack");
        int DMGRoll = Random.Range(4, 7);
        HPSystem.DMGTakenBoss = DMGRoll;
        HPSystem.PlayerDef += 2;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }



    //Turn the buttons off, trigger the Fireball animation, roll for damage, do that damage, tell the system its now the bosses turn, and trigger the sound effects
    public void Fireball()
    {
        TurnsSystem.UIOff();
        Mage.GetComponent<Animator>().SetTrigger("1stAttack");
        int DMGRoll = Random.Range(10, 14);
        HPSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }

    //Turn the buttons off, trigger the Heal Spell animation, add HP, take away defense stats, tell the system its now the bosses turn, and update the HP bars
    public void HealSpell()
    {
        TurnsSystem.UIOff();
        Mage.GetComponent<Animator>().SetTrigger("2ndAttack");
        HPSystem.PlayerHPNum += 25;
        HPSystem.PlayerDef -= 4;
        TurnsSystem.BossTurn();
        HPSystem.PlayerSliderUpdate();
        HPSystem.BossSliderUpdate();
    }

    //Turn the buttons off, trigger the Flying Swords animation, set the amount of pierce turns, set pierce damage, stun the player, tell the system its now the bosses turn, and update the HP bars
    public void FlyingSwords()
    {
        TurnsSystem.UIOff();
        Mage.GetComponent<Animator>().SetTrigger("3rdAttack");
        BossPierced = 2;
        PierceDMG = 6;
        PlayerStunned += 1;
        TurnsSystem.BossTurn();
        HPSystem.PlayerSliderUpdate();
        HPSystem.BossSliderUpdate();
    }



    //Check if the boss has buffed itself yet, if it hasnt, turn the buttons off, trigger the Spirit Arrow animation, roll for damage, do that damage, add HP, stun the boss, tell the system its now the bosses turn, and trigger the sound effects, but if the boss has buffed itself then it will turn the buttons off, heal HP, tell the system its now the bosses turns, and lastly update the HP bars
    public void SpiritArrow()
    {
        if(BossBuffed == false)
        {
            TurnsSystem.UIOff();
            Archer.GetComponent<Animator>().SetTrigger("1stAttack");
            int DMGRoll = Random.Range(8, 12);
            HPSystem.DMGTakenBoss = DMGRoll;
            HPSystem.PlayerHPNum += 7;
            BossStunned += 1;
            TurnsSystem.BossTurn();
            Invoke("SlowBAudio", 1.5f);
        } else
        {
            TurnsSystem.UIOff();
            HPSystem.PlayerHPNum += 7;
            TurnsSystem.BossTurn();
            HPSystem.PlayerSliderUpdate();
            HPSystem.BossSliderUpdate();
        }
    }

    //Turn the buttons off, trigger the Fallen Arrow animation, take away HP, add to the maximum HP, tell the system its now the bosses turn, and trigger the sound effects
    public void FallenArrow()
    {
        TurnsSystem.UIOff();
        Archer.GetComponent<Animator>().SetTrigger("2ndAttack");
        HPSystem.PlayerHPNum -= 7;
        HPSystem.PlayerHPNumMax += 10;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }

    //Turn the buttons off, trigger the Arrow Rain animation, roll for damage, do that damage, set the amount of Boss pierced turns, set pierce damage, take away the bosses defense, tell the system its now the bosses turn, and trigger the sound effects
    public void ArrowRain()
    {
        TurnsSystem.UIOff();
        Archer.GetComponent<Animator>().SetTrigger("3rdAttack");
        int DMGRoll = Random.Range(2, 8);
        HPSystem.DMGTakenBoss = DMGRoll;
        BossPierced = 1;
        PierceDMG = 5;
        HPSystem.BossDef -= 3;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }

    //Update the HP bars and play the sound effects for when the boss takes damage
    void SlowBAudio()
    {
        HPSystem.PlayerSliderUpdate();
        HPSystem.BossSliderUpdate();
        BDamage.Play();
    }

    //Update the HP bars and play the sound effects for when the player takes damage
    void SlowPAudio()
    {
        HPSystem.PlayerSliderUpdate();
        HPSystem.BossSliderUpdate();
        PDamage.Play();
    }


    
    public void BossAttack()
    {
        //Checks if the Boss is stunned if it is decreases the stun count by one and tells the system its the players turn
        if (BossStunned == 0)
        {
            //Rolls for an attack
            int Diceroll = Random.Range(1, 4);

            //If it rolls 1 then it activates the bosses canvas, activates the first attacks objects, triggers the bosses 1st attacks animations, rolls for damage, does that damage, takes away the players defense, and triggers the sound effects
            if (Diceroll == 1)
            {
                TurnsSystem.TheBossesCanvas.SetActive(true);
                TurnsSystem.FirstAttackObject.SetActive(true);
                TheBoss.GetComponent<Animator>().SetTrigger("1stAttack");
                int DMGRoll = Random.Range(1, 4);
                HPSystem.DMGTakenBoss = DMGRoll;
                HPSystem.PlayerDef -= 3;
                Invoke("SlowPAudio", 1.5f);
            }

            //If it rolls 2 then it activates the bosses canvas, activates the second attacks objects, triggers the bosses 2nd attacks animations, rolls for damage, does that damage, takes away its own defense, and triggers the sound effects
            else if (Diceroll == 2)
            {
                TurnsSystem.TheBossesCanvas.SetActive(true);
                TurnsSystem.SecondAttackObject.SetActive(true);
                TheBoss.GetComponent<Animator>().SetTrigger("2ndAttack");
                int DMGRoll = Random.Range(7, 13);
                HPSystem.DMGTakenPlayer = DMGRoll;
                HPSystem.BossDef -= 2;
                Invoke("SlowPAudio", 1.5f);
            }

            //If it rolls 4 then it activates the bosses canvas, activates the third attacks objects, triggers the bosses 3rd attacks animations, adds defense, heals HP, and updates the HP bars
            else if (Diceroll == 3)
            {
                TurnsSystem.TheBossesCanvas.SetActive(true);
                TurnsSystem.ThirdAttackObject.SetActive(true);
                TheBoss.GetComponent<Animator>().SetTrigger("3rdAttack");
                HPSystem.BossDef += 2;
                HPSystem.BossHPNum += 4;
                HPSystem.PlayerSliderUpdate();
                HPSystem.BossSliderUpdate();
            }
        } else 
        {
            //Takes away a stun count for the turn and afters tells the system its now the players turn
            BossStunned -= 1;
            if(BossStunned == 0)
            {

            }
            TurnsSystem.TurnSet();
        }

        //Checks for pierce counts, if the boss does have pierce counts does damage for the amount of previously set pierce damage, and then updates the bosses own HP bar
        if(BossPierced > 0)
        {
            BossPierced -= 1;
            HPSystem.DMGTakenBoss = PierceDMG;
            HPSystem.BossSliderUpdate();
        }
    }
}