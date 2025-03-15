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
    public bool PlayerBuffed;

    [Header("GameObjects")]
    public GameObject TheBoss;
    public GameObject Warrior;
    public GameObject Mage;
    public GameObject Archer;
    public GameObject BossStunnedIcon;

    [Header("Attack Vars")]
    public bool PlayerStunned;
    public bool BossStunned;
    public int AttackDisabled;

    [Header("Text Vars")]
    public TextMeshProUGUI PlayerLoseHealth;
    public TextMeshProUGUI PlayerGainHealth;
    public TextMeshProUGUI PlayerLoseDefense;
    public TextMeshProUGUI PlayerGainDefense;
    public TextMeshProUGUI BossLoseHealth;
    public TextMeshProUGUI BossGainHealth;
    public TextMeshProUGUI BossLoseDefense;
    public TextMeshProUGUI BossGainDefense;

    [Header("Audio")]
    public AudioSource BDamage;
    public AudioSource PDamage;

    [Header("Texts")]
    public TextMeshProUGUI AttackDisabledText;

    private void Start()
    {
        PlayerLoseHealth.text = "";
        PlayerGainHealth.text = "";
        PlayerLoseDefense.text = "";
        PlayerGainDefense.text = "";
        BossLoseHealth.text = "";
        BossGainHealth.text = "";
        BossLoseDefense.text = "";
        BossGainDefense.text = "";
    }

    private void Update()
    {
        if(BossStunned == true)
        {
            BossStunnedIcon.SetActive(true);
        }
        
        if(BossStunned == false)
        {
            BossStunnedIcon.SetActive(false);
        }
    }

    //Turn the buttons off, trigger the Tennis Ball Throw animation, roll for damage, do that damage, tell the system its now the bosses turn, and trigger the sound effects
    public void BallThrow()
    {
        TurnsSystem.UIOff();
        DMGRoll = Random.Range(5, 9);
        Warrior.GetComponent<Animator>().SetTrigger("1stAttack");
        if (HpSystem.BossDef > DMGRoll)
        {
            DMGRoll = 0;
        }
        BossLoseHealth.text = "-" + DMGRoll.ToString();
        HpSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.CheckDisabledAttack();
        TurnsSystem.BossTurnExtended();
        Invoke("SlowBAudio", 1.5f);
    }

    //Turn the buttons off, trigger the Spin Attack animation, roll for damage, do that damage, add defense stats, tell the system its now the bosses turn, and trigger the sound effects
    public void SpinSmack()
    {
        TurnsSystem.UIOff();
        DMGRoll = Random.Range(3, 7);
        HpSystem.PlayerDef += 2;
        Warrior.GetComponent<Animator>().SetTrigger("2ndAttack");
        if (HpSystem.BossDef > DMGRoll)
        {
            DMGRoll = 0;
        }
        BossLoseHealth.text = "-" + DMGRoll.ToString();
        PlayerGainDefense.text = "+2";
        HpSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.CheckDisabledAttack();
        TurnsSystem.BossTurnExtended();
        Invoke("SlowBAudio", 1.5f);
    }

    //Turn the buttons off, trigger the Disrespectful Slap animation, roll for damage, do that damage, add defense stats, tell the system its now the bosses turn, and trigger the sound effects
    public void StrongSlap()
    {
        TurnsSystem.UIOff();
        DMGRoll = Random.Range(2, 6);
        AttackDisabled = 2;
        BossStunned = true;
        Warrior.GetComponent<Animator>().SetTrigger("3rdAttack");
        if (HpSystem.BossDef > DMGRoll)
        {
            DMGRoll = 0;
        }
        BossLoseHealth.text = "-" + DMGRoll.ToString();
        HpSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurnStunned();
        Invoke("SlowBAudio", 1.5f);
    }



    //Turn the buttons off, trigger the Fireball animation, roll for damage, do that damage, tell the system its now the bosses turn, and trigger the sound effects
    public void Fireball()
    {
        TurnsSystem.UIOff();
        DMGRoll = Random.Range(10, 14);
        Mage.GetComponent<Animator>().SetTrigger("1stAttack");
        if (HpSystem.BossDef > DMGRoll)
        {
            DMGRoll = 0;
        }
        BossLoseHealth.text += "-" + DMGRoll.ToString();
        HpSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }

    //Turn the buttons off, trigger the Heal Spell animation, add HP, take away defense stats, tell the system its now the bosses turn, and update the HP bars
    public void HealSpell()
    {
        TurnsSystem.UIOff();
        HpSystem.PlayerHPNum += 25;
        HpSystem.PlayerDef -= 4;
        Mage.GetComponent<Animator>().SetTrigger("2ndAttack");
        PlayerGainHealth.text = "+25";
        BossLoseDefense.text = "-4";
        TurnsSystem.BossTurnExtended();
        Invoke("SlowBAudio", 1.5f);
    }

    //Turn the buttons off, trigger the Flying Swords animation, set the amount of pierce turns, set pierce damage, stun the player, tell the system its now the bosses turn, and update the HP bars
    public void TwoSwords()
    {
        TurnsSystem.UIOff();
        DMGRoll = Random.Range(16, 20);
        HpSystem.PlayerDef -= 5;
        Mage.GetComponent<Animator>().SetTrigger("3rdAttack");
        if (HpSystem.BossDef > DMGRoll)
        {
            DMGRoll = 0;
        }
        BossLoseHealth.text = "-" + DMGRoll.ToString();
        BossLoseDefense.text = "-5";
        HpSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurnMoreExtended();
        Invoke("SlowBAudio", 1.5f);
    }



    //Check if the boss has buffed itself yet, if it hasnt, turn the buttons off, trigger the Spirit Arrow animation, roll for damage, do that damage, add HP, stun the boss, tell the system its now the bosses turn, and trigger the sound effects, but if the boss has buffed itself then it will turn the buttons off, heal HP, tell the system its now the bosses turns, and lastly update the HP bars
    public void SpiritArrow()
    {
        if(HpSystem.BossDef >= 1)
        {
            TurnsSystem.UIOff();
            DMGRoll = Random.Range(6, 10);
            HpSystem.PlayerHPNum += 7;
            HpSystem.BossDef -= 3;
            BossStunned = true;
            Archer.GetComponent<Animator>().SetTrigger("1stAttack");
            if (HpSystem.BossDef > DMGRoll)
            {
                DMGRoll = 0;
            }
            BossLoseHealth.text = "-" + DMGRoll.ToString();
            PlayerLoseDefense.text = "-3";
            PlayerGainHealth.text = "+7";
            HpSystem.DMGTakenBoss = DMGRoll;
            TurnsSystem.BossTurn();
            Invoke("SlowBAudio", 1.5f);
        } else
        {
            TurnsSystem.UIOff();
            DMGRoll = Random.Range(6, 10);
            HpSystem.PlayerHPNum += 7;
            HpSystem.BossDef -= 3;
            Archer.GetComponent<Animator>().SetTrigger("1stAttack");
            if (HpSystem.BossDef > DMGRoll)
            {
                DMGRoll = 0;
            }
            BossLoseHealth.text = "-" + DMGRoll.ToString();
            PlayerLoseDefense.text = "-3";
            PlayerGainHealth.text = "+7";
            HpSystem.DMGTakenBoss = DMGRoll;
            TurnsSystem.BossTurn();
            Invoke("SlowBAudio", 1.5f);
        }
    }

    //Turn the buttons off, trigger the Fallen Arrow animation, take away HP, add to the maximum HP, tell the system its now the bosses turn, and trigger the sound effects
    public void FallenArrow()
    {
        TurnsSystem.UIOff();
        HpSystem.PlayerHPNum -= 5;
        HpSystem.PlayerDef += 3;
        Archer.GetComponent<Animator>().SetTrigger("2ndAttack");
        PlayerLoseHealth.text = "-5";
        PlayerGainDefense.text = "+3";
        TurnsSystem.BossTurn();
        Invoke("SlowPAudio", 1.5f);
    }

    //Turn the buttons off, trigger the Arrow Rain animation, roll for damage, do that damage, set the amount of Boss pierced turns, set pierce damage, take away the bosses defense, tell the system its now the bosses turn, and trigger the sound effects
    public void ArrowRain()
    {
        TurnsSystem.UIOff();
        DMGRoll = Random.Range(3, 7);
        HpSystem.BossDef -= 3;
        Archer.GetComponent<Animator>().SetTrigger("3rdAttack");
        if (HpSystem.BossDef > DMGRoll)
        {
            DMGRoll = 0;
        }
        BossLoseHealth.text = "-" + DMGRoll.ToString();
        PlayerLoseDefense.text = "-3";
        HpSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }

    //Update the HP bars and play the sound effects for when the boss takes damage
    void SlowBAudio()
    {
        HpSystem.PlayerSliderUpdate();
        HpSystem.BossSliderUpdate();
        PlayerLoseHealth.text = "";
        PlayerGainHealth.text = "";
        PlayerLoseDefense.text = "";
        PlayerGainDefense.text = "";
        BossLoseHealth.text = "";
        BossGainHealth.text = "";
        BossLoseDefense.text = "";
        BossGainDefense.text = "";
        BDamage.Play();
    }

    //Update the HP bars and play the sound effects for when the player takes damage
    void SlowPAudio()
    {
        HpSystem.PlayerSliderUpdate();
        HpSystem.BossSliderUpdate();
        PlayerLoseHealth.text = "";
        PlayerGainHealth.text = "";
        PlayerLoseDefense.text = "";
        PlayerGainDefense.text = "";
        BossLoseHealth.text = "";
        BossGainHealth.text = "";
        BossLoseDefense.text = "";
        BossGainDefense.text = "";
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
                HpSystem.PlayerDef -= 3;
                TheBoss.GetComponent<Animator>().SetTrigger("1stAttack");
                if (HpSystem.PlayerDef > DMGRoll)
                {
                    DMGRoll = 0;
                }
                PlayerLoseHealth.text = "-" + DMGRoll.ToString();
                BossLoseDefense.text = "-3";
                HpSystem.DMGTakenPlayer = DMGRoll;
                Invoke("SlowPAudio", 1.5f);
                TurnsSystem.Turn = 2;
                TurnsSystem.TurnSet();
            }

            //If it rolls 2 then it activates the bosses canvas, activates the second attacks objects, triggers the bosses 2nd attacks animations, rolls for damage, does that damage, takes away its own defense, and triggers the sound effects
            else if (Diceroll == 2)
            {
                TurnsSystem.TheBossesCanvas.SetActive(true);
                TurnsSystem.SecondAttackObject.SetActive(true);
                DMGRoll = Random.Range(7, 13);
                HpSystem.BossDef -= 2;
                TheBoss.GetComponent<Animator>().SetTrigger("2ndAttack");
                if (HpSystem.PlayerDef > DMGRoll)
                {
                    DMGRoll = 0;
                }
                PlayerLoseHealth.text = "-" + DMGRoll.ToString();
                PlayerLoseDefense.text = "-2";
                HpSystem.DMGTakenPlayer = DMGRoll;
                Invoke("SlowPAudio", 1.5f);
                TurnsSystem.Turn = 2;
                TurnsSystem.TurnSet();
            }

            //If it rolls 4 then it activates the bosses canvas, activates the third attacks objects, triggers the bosses 3rd attacks animations, adds defense, heals HP, and updates the HP bars
            else if (Diceroll == 3)
            {
                TurnsSystem.TheBossesCanvas.SetActive(true);
                TurnsSystem.ThirdAttackObject.SetActive(true);
                HpSystem.BossHPNum += 4;
                HpSystem.BossDef += 2;
                TheBoss.GetComponent<Animator>().SetTrigger("3rdAttack");
                if (HpSystem.PlayerDef > DMGRoll)
                {
                    DMGRoll = 0;
                }
                BossGainHealth.text = "+4";
                BossGainDefense.text = "+2";
                Invoke("SlowPAudio", 1.5f);
                TurnsSystem.Turn = 2;
                TurnsSystem.TurnSet();
            }
        }
        
        if (BossStunned == true)
        {
            TurnsSystem.Turn = 2;
            TurnsSystem.TurnSet();
            BossStunned = false;
        }
    }
}
