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

    // Start is called before the first frame update

    public void Update()
    {
        
    }

    public void TennisBallThrow()
    {
        TurnsSystem.UIOff();
        Warrior.GetComponent<Animator>().SetTrigger("1stAttack");
        int DMGRoll = Random.Range(7, 11);
        HPSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }
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




    public void Fireball()
    {
        TurnsSystem.UIOff();
        Mage.GetComponent<Animator>().SetTrigger("1stAttack");
        int DMGRoll = Random.Range(10, 14);
        HPSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }
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
    public void FallenArrow()
    {
        TurnsSystem.UIOff();
        Archer.GetComponent<Animator>().SetTrigger("2ndAttack");
        HPSystem.PlayerHPNum -= 7;
        HPSystem.PlayerHPNumMax += 10;
        TurnsSystem.BossTurn();
        Invoke("SlowBAudio", 1.5f);
    }
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

    void SlowBAudio()
    {
        HPSystem.PlayerSliderUpdate();
        HPSystem.BossSliderUpdate();
        BDamage.Play();
    }

    void SlowPAudio()
    {
        HPSystem.PlayerSliderUpdate();
        HPSystem.BossSliderUpdate();
        PDamage.Play();
    }

    public void BossAttack()
    {
        if (BossStunned == 0)
        {
            if (BossCheck == 1)
            {

                int Diceroll = Random.Range(1, 4);
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
            }
        } else
        {
            BossStunned -= 1;
            if(BossStunned == 0)
            {

            }
            TurnsSystem.TurnSet();
        }

        if(BossPierced > 0)
        {
            BossPierced -= 1;
            HPSystem.DMGTakenBoss = PierceDMG;
            HPSystem.BossSliderUpdate();
        }
    }
}
