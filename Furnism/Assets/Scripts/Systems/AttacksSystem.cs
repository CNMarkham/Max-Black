using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttacksSystem : MonoBehaviour
{
    [Header("Other Script References")]
    public HPSystem HpSystem;
    public TurnsSystem TurnsSystem;

    [Header("Boss Vars")]
    public int BossCheck;
    public int Diceroll;
    public bool BossBuffed; 

    [Header("Player Vars")]
    public int DMGRoll;
    public int HEALAmount;
    public bool PlayerBuffed;

    [Header("GameObjects")]
    public GameObject TheBoss;
    public GameObject Warrior;
    public GameObject Mage;
    public GameObject Archer;
    public GameObject PStunIcon;
    public GameObject BStunIcon;

    [Header("Attack Vars")]
    public bool PlayerStunned;
    public bool BossStunned;
    public int AttackDisabled;

    [Header("Audio")]
    public AudioSource BDamage;
    public AudioSource PDamage;

    [Header("Texts")]
    public TextMeshProUGUI PlayerAttackValue;
    public TextMeshProUGUI HealText;
    public TextMeshProUGUI BossAttackValue;
    public TextMeshProUGUI AttackDisabledText;

    private void Update()
    {
        if(PlayerStunned == true)
        {
            PStunIcon.SetActive(true);
        }

        if(BossStunned == true)
        {
            BStunIcon.SetActive(true);
        }
    }

    //PlayerAttackValue text makes itself the damage output of the attack.
    public void PlayerAttackTextON()
    {
        PlayerAttackValue.text = ("-" + DMGRoll.ToString());
    }

    //PlayerAttackValue text looks blank 
    public void PlayerAttackTextOFF()
    {
        PlayerAttackValue.text = "";
    }

    //HealText shows you the amount you healed
    public void HealAmountTextON()
    {
        HealText.text = ("+" + HEALAmount.ToString());
    }

    //HealText looks blank
    public void HealAmountTextOFF()
    {
        HealText.text = "";
    }

    //BossAttackValue text looks blank 
    public void BossAttackTextON()
    {
        BossAttackValue.text = ("-" + DMGRoll.ToString());
    }

    //BossAttackValue text looks blank 
    public void BossAttackTextOFF()
    {
        BossAttackValue.text = "";
    }


    //Turn the buttons off, trigger the Tennis Ball Throw animation, roll for damage, do that damage, tell the system its now the bosses turn, and trigger the sound effects
    public void BallThrow()
    {
        TurnsSystem.UIOff();
        DMGRoll = Random.Range(5, 9);
        Invoke("PlayerAttackTextON", 1.5f);
        Invoke("PlayerAttackTextOFF", 8f);
        Warrior.GetComponent<Animator>().SetTrigger("1stAttack");
        HpSystem.DMGTakenBoss -= DMGRoll;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }

    //Turn the buttons off, trigger the Spin Attack animation, roll for damage, do that damage, add defense stats, tell the system its now the bosses turn, and trigger the sound effects
    public void SpinSmack()
    {
        TurnsSystem.UIOff();
        DMGRoll = Random.Range(3, 7);
        Invoke("PlayerAttackTextON", 1.5f);
        Invoke("PlayerAttackTextOFF", 8f);
        Warrior.GetComponent<Animator>().SetTrigger("2ndAttack");
        HpSystem.DMGTakenBoss -= DMGRoll;
        HpSystem.PlayerDef += 2;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }

    //Turn the buttons off, trigger the Disrespectful Slap animation, roll for damage, do that damage, add defense stats, tell the system its now the bosses turn, and trigger the sound effects
    public void StrongSlap()
    {
        TurnsSystem.UIOff();
        DMGRoll = Random.Range(2, 6);
        Invoke("PlayerAttackTextON", 1.5f);
        Invoke("PlayerAttackTextOFF", 8f);
        Warrior.GetComponent<Animator>().SetTrigger("3rdAttack");
        HpSystem.DMGTakenBoss -= DMGRoll;
        BossStunned = true;
        AttackDisabled = 2;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }



    //Turn the buttons off, trigger the Fireball animation, roll for damage, do that damage, tell the system its now the bosses turn, and trigger the sound effects
    public void Fireball()
    {
        TurnsSystem.UIOff();
        DMGRoll = Random.Range(10, 14);
        Invoke("PlayerAttackTextON", 1.5f);
        Invoke("PlayerAttackTextOFF", 8f);
        Mage.GetComponent<Animator>().SetTrigger("1stAttack");
        HpSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }

    //Turn the buttons off, trigger the Heal Spell animation, add HP, take away defense stats, tell the system its now the bosses turn, and update the HP bars
    public void HealSpell()
    {
        TurnsSystem.UIOff();
        HEALAmount = 25;
        Invoke("HealAmountTextON", 1.5f);
        Invoke("HealAmountTextOFF", 8f);
        Mage.GetComponent<Animator>().SetTrigger("2ndAttack");
        HpSystem.PlayerHPNum += 25;
        HpSystem.PlayerDef -= 4;
        TurnsSystem.BossTurn();
        HpSystem.PlayerSliderUpdate();
        HpSystem.BossSliderUpdate();
    }

    //Turn the buttons off, trigger the Flying Swords animation, set the amount of pierce turns, set pierce damage, stun the player, tell the system its now the bosses turn, and update the HP bars
    public void TwoSwords()
    {
        TurnsSystem.UIOff();
        DMGRoll = Random.Range(16, 20);
        Invoke("PlayerAttackTextON", 1.5f);
        Invoke("PlayerAttackTextOFF", 8f);
        Mage.GetComponent<Animator>().SetTrigger("3rdAttack");
        HpSystem.DMGTakenBoss = DMGRoll;
        HpSystem.PlayerDef -= 5;
        TurnsSystem.BossTurn();
        HpSystem.PlayerSliderUpdate();
        HpSystem.BossSliderUpdate();
        Invoke("SlowBAudio", 1.5f);
    }



    //Check if the boss has buffed itself yet, if it hasnt, turn the buttons off, trigger the Spirit Arrow animation, roll for damage, do that damage, add HP, stun the boss, tell the system its now the bosses turn, and trigger the sound effects, but if the boss has buffed itself then it will turn the buttons off, heal HP, tell the system its now the bosses turns, and lastly update the HP bars
    public void SpiritArrow()
    {
        if(HpSystem.BossDef >= 1)
        {
            TurnsSystem.UIOff();
            DMGRoll = Random.Range(6, 10);
            HEALAmount = 5;
            Invoke("HealAmountTextON", 1.5f);
            Invoke("HealAmountTextOFF", 8f);
            Invoke("PlayerAttackTextON", 1.5f);
            Invoke("PlayerAttackTextOFF", 8f);
            Archer.GetComponent<Animator>().SetTrigger("1stAttack");
            HpSystem.DMGTakenBoss = DMGRoll;
            HpSystem.PlayerHPNum += 7;
            BossStunned = true;
            TurnsSystem.BossTurn();
            HpSystem.PlayerSliderUpdate();
            HpSystem.BossSliderUpdate();
            Invoke("SlowBAudio", 1.5f);
        } else
        {
            TurnsSystem.UIOff();
            DMGRoll = Random.Range(6, 10);
            HEALAmount = 5;
            Invoke("HealAmountTextON", 1.5f);
            Invoke("HealAmountTextOFF", 8f);
            Invoke("PlayerAttackTextON", 1.5f);
            Invoke("PlayerAttackTextOFF", 8f);
            Archer.GetComponent<Animator>().SetTrigger("1stAttack");
            HpSystem.DMGTakenBoss = DMGRoll;
            HpSystem.PlayerHPNum += 7;
            TurnsSystem.BossTurn();
            HpSystem.PlayerSliderUpdate();
            HpSystem.BossSliderUpdate();
            Invoke("SlowBAudio", 1.5f);
        }
    }

    //Turn the buttons off, trigger the Fallen Arrow animation, take away HP, add to the maximum HP, tell the system its now the bosses turn, and trigger the sound effects
    public void FallenArrow()
    {
        TurnsSystem.UIOff();
        Archer.GetComponent<Animator>().SetTrigger("2ndAttack");
        HpSystem.PlayerHPNum -= 5;
        HpSystem.PlayerDef += 3;
        TurnsSystem.BossTurn();
        Invoke("SlowPAudio", 1.5f);
    }

    //Turn the buttons off, trigger the Arrow Rain animation, roll for damage, do that damage, set the amount of Boss pierced turns, set pierce damage, take away the bosses defense, tell the system its now the bosses turn, and trigger the sound effects
    public void ArrowRain()
    {
        TurnsSystem.UIOff();
        DMGRoll = Random.Range(3, 7);
        Invoke("PlayerAttackTextON", 1.5f);
        Invoke("PlayerAttackTextOFF", 8f);
        Archer.GetComponent<Animator>().SetTrigger("3rdAttack");
        HpSystem.DMGTakenBoss = DMGRoll;
        HpSystem.BossDef -= 3;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }

    //Update the HP bars and play the sound effects for when the boss takes damage
    void SlowBAudio()
    {
        HpSystem.PlayerSliderUpdate();
        HpSystem.BossSliderUpdate();
        BDamage.Play();
    }

    //Update the HP bars and play the sound effects for when the player takes damage
    void SlowPAudio()
    {
        HpSystem.PlayerSliderUpdate();
        HpSystem.BossSliderUpdate();
        PDamage.Play();
    }
    
    public void BossAttack()
    {
        //Checks if the Boss is stunned if it is decreases the stun count by one and tells the system its the players turn
        if (BossStunned == false)
        {
            //Rolls for an attack
            int Diceroll = Random.Range(1, 4);

            //If it rolls 1 then it activates the bosses canvas, activates the first attacks objects, triggers the bosses 1st attacks animations, rolls for damage, does that damage, takes away the players defense, and triggers the sound effects
            if (Diceroll == 1)
            {
                TurnsSystem.TheBossesCanvas.SetActive(true);
                TurnsSystem.FirstAttackObject.SetActive(true);
                DMGRoll = Random.Range(1, 4);
                Invoke("BossAttackTextON", 1.5f);
                Invoke("BossAttackTextOFF", 8f);
                TheBoss.GetComponent<Animator>().SetTrigger("1stAttack");
                HpSystem.DMGTakenBoss = DMGRoll;
                HpSystem.PlayerDef -= 3;
                Invoke("SlowPAudio", 1.5f);
                TurnsSystem.TurnSet();
            }

            //If it rolls 2 then it activates the bosses canvas, activates the second attacks objects, triggers the bosses 2nd attacks animations, rolls for damage, does that damage, takes away its own defense, and triggers the sound effects
            else if (Diceroll == 2)
            {
                TurnsSystem.TheBossesCanvas.SetActive(true);
                TurnsSystem.SecondAttackObject.SetActive(true);
                DMGRoll = Random.Range(7, 13);
                Invoke("BossAttackTextON", 1.5f);
                Invoke("BossAttackTextOFF", 8f);
                TheBoss.GetComponent<Animator>().SetTrigger("2ndAttack");
                HpSystem.DMGTakenPlayer = DMGRoll;
                HpSystem.BossDef -= 2;
                Invoke("SlowPAudio", 1.5f);
                TurnsSystem.TurnSet();
            }

            //If it rolls 4 then it activates the bosses canvas, activates the third attacks objects, triggers the bosses 3rd attacks animations, adds defense, heals HP, and updates the HP bars
            else if (Diceroll == 3)
            {
                TurnsSystem.TheBossesCanvas.SetActive(true);
                TurnsSystem.ThirdAttackObject.SetActive(true);
                TheBoss.GetComponent<Animator>().SetTrigger("3rdAttack");
                HpSystem.BossDef += 2;
                HpSystem.BossHPNum += 4;
                HpSystem.PlayerSliderUpdate();
                HpSystem.BossSliderUpdate();
                TurnsSystem.TurnSet();
            }
        }
        
        if (BossStunned = true)
        {
            TurnsSystem.TurnSet();
            BossStunned = false;
        }
    }
}
