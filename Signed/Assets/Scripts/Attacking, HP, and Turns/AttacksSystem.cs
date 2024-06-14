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
    public GameObject TheBossesCanvas;
    public GameObject Warrior;
    public GameObject Mage;
    public GameObject Archer;

    [Header("The Boss Attacks GameObjects")]
    public GameObject FirstAttackObject;
    public GameObject SecondAttackObject;
    public GameObject ThirdAttackObject;

    [Header("Stun GameObjects")]
    public GameObject StunImagePlayer;
    public GameObject StunImageBoss;
    public TextMeshProUGUI StunTextPlayer;
    public TextMeshProUGUI StunTextBoss;

    [Header("Attack Vars")]
    public int PlayerStunned;
    public int BossStunned;

    // Start is called before the first frame update

    public void Update()
    {
        if(PlayerStunned >= 1)
        {
            StunImagePlayer.SetActive(true);
            StunTextPlayer.text = (PlayerStunned.ToString());
        }

        if(BossStunned >= 1)
        {
            StunImageBoss.SetActive(true);
            StunTextBoss.text = (BossStunned.ToString());
        }

        if(PlayerStunned == 0)
        {
            StunImagePlayer.SetActive(false);
            StunTextPlayer.text = " ";
        }

        if(BossStunned == 0)
        {
            StunImageBoss.SetActive(false);
            StunTextBoss.text = " ";
        }
    }

    public void TennisBallThrow()
    {
        TurnsSystem.UIOff();
        Warrior.GetComponent<Animator>().SetTrigger("1stAttack");
        int DMGRoll = Random.Range(7, 11);
        HPSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurn();
        HPSystem.PlayerSliderUpdate();
        HPSystem.BossSliderUpdate();
    }
    public void SpinAttack()
    {
        TurnsSystem.UIOff();
        Warrior.GetComponent<Animator>().SetTrigger("2ndAttack");
        int DMGRoll = Random.Range(5, 9);
        BossStunned += 1;
        HPSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurn();
        HPSystem.PlayerSliderUpdate();
        HPSystem.BossSliderUpdate();
    }
    public void DisrespectfulSlap()
    {
        TurnsSystem.UIOff();
        Warrior.GetComponent<Animator>().SetTrigger("3rdAttack");
        int DMGRoll = Random.Range(4, 7);
        HPSystem.DMGTakenBoss = DMGRoll;
        HPSystem.PlayerDef += 2;
        PlayerBuffed = true;
        TurnsSystem.BossTurn();
        HPSystem.PlayerSliderUpdate();
        HPSystem.BossSliderUpdate();
    }




    public void Fireball()
    {
        TurnsSystem.UIOff();
        Mage.GetComponent<Animator>().SetTrigger("1stAttack");
        int DMGRoll = Random.Range(10, 16);
        HPSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurn();
        HPSystem.PlayerSliderUpdate();
        HPSystem.BossSliderUpdate();
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
            int DMGRoll = Random.Range(8, 14);
            HPSystem.DMGTakenBoss = DMGRoll;
            HPSystem.PlayerHPNum += 7;
            TurnsSystem.BossTurn();
            HPSystem.PlayerSliderUpdate();
            HPSystem.BossSliderUpdate();
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
        HPSystem.PlayerSliderUpdate();
        HPSystem.BossSliderUpdate();
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
        HPSystem.PlayerSliderUpdate();
        HPSystem.BossSliderUpdate();
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
                    TheBossesCanvas.SetActive(true);
                    FirstAttackObject.SetActive(true);
                    TheBoss.GetComponent<Animator>().SetTrigger("1stAttack");
                    int DMGRoll = Random.Range(1, 4);
                    HPSystem.DMGTakenBoss = DMGRoll;
                    HPSystem.PlayerDef -= 3;
                    HPSystem.PlayerSliderUpdate();
                    HPSystem.BossSliderUpdate();
                    TheBossesCanvas.SetActive(false);
                    FirstAttackObject.SetActive(false);
                    TurnsSystem.UIOn();
                }
                else if (Diceroll == 2)
                {
                    TheBossesCanvas.SetActive(true);
                    SecondAttackObject.SetActive(true);
                    TheBoss.GetComponent<Animator>().SetTrigger("2ndAttack");
                    int DMGRoll = Random.Range(7, 13);
                    HPSystem.DMGTakenPlayer = DMGRoll;
                    HPSystem.BossDef -= 3;
                    HPSystem.PlayerSliderUpdate();
                    HPSystem.BossSliderUpdate();
                    TheBossesCanvas.SetActive(false);
                    SecondAttackObject.SetActive(false);
                    TurnsSystem.UIOn();
                }
                else if (Diceroll == 3)
                {
                    TheBossesCanvas.SetActive(true);
                    ThirdAttackObject.SetActive(true);
                    TheBoss.GetComponent<Animator>().SetTrigger("3rdAttack");
                    HPSystem.BossDef += 2;
                    HPSystem.BossHPNum += 4;
                    HPSystem.PlayerSliderUpdate();
                    HPSystem.BossSliderUpdate();
                    TheBossesCanvas.SetActive(false);
                    ThirdAttackObject.SetActive(false);
                    TurnsSystem.UIOn();
                }
            }
            else if (BossCheck == 2)
            {
                int Diceroll = Random.Range(0, 3);
                if (Diceroll == 1)
                {

                }
                else if (Diceroll == 2)
                {

                }
                else
                {

                }
            }
            else
            {
                int Diceroll = Random.Range(0, 3);
                if (Diceroll == 1)
                {

                }
                else if (Diceroll == 2)
                {

                }
                else
                {

                }
            } 
        } else
        {
            BossStunned -= 1;
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
