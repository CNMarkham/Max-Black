using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("Attack Vars")]
    public int PlayerStunned;
    public int BossStunned;

    // Start is called before the first frame update

    public void TennisBallThrow()
    {
        GetComponent<Animator>().SetTrigger("1stAttack");
        int DMGRoll = Random.Range(7, 10);
        HPSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurn();
    }
    public void SpinAttack()
    {
        GetComponent<Animator>().SetTrigger("2ndAttack");
        int DMGRoll = Random.Range(5, 8);
        BossStunned += 1;
        HPSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurn();
    }
    public void DisrespectfulSlap()
    {
        GetComponent<Animator>().SetTrigger("3rdAttack");
        int DMGRoll = Random.Range(4, 6);
        HPSystem.DMGTakenBoss = DMGRoll;
        HPSystem.PlayerDef += 2;
        PlayerBuffed = true;
        TurnsSystem.BossTurn();
    }




    public void Fireball()
    {
        GetComponent<Animator>().SetTrigger("1stAttack");
        int DMGRoll = Random.Range(10, 15);
        HPSystem.DMGTakenBoss = DMGRoll;
        TurnsSystem.BossTurn();
    }
    public void HealSpell()
    {
        HPSystem.PlayerHPNum += 25;
        HPSystem.PlayerDef -= 4;
        TurnsSystem.BossTurn();
    }
    public void FlyingSwords()
    {
        BossPierced = 2;
        PierceDMG = 6;
        PlayerStunned += 1;
        TurnsSystem.BossTurn();
    }




    public void SpiritArrow()
    {
        if(BossBuffed == false)
        {
            GetComponent<Animator>().SetTrigger("1stAttack");
            int DMGRoll = Random.Range(8, 13);
            HPSystem.DMGTakenBoss = DMGRoll;
            HPSystem.PlayerHPNum += 7;
            TurnsSystem.BossTurn();
        } else
        {
            HPSystem.PlayerHPNum += 7;
            TurnsSystem.BossTurn();
            //Dont do the attack
        }
    }
    public void FallenArrow()
    {
        HPSystem.PlayerHPNum -= 7;
        HPSystem.PlayerHPNumMax += 10;
        TurnsSystem.BossTurn();
    }
    public void ArrowRain()
    {
        GetComponent<Animator>().SetTrigger("3rdAttack");
        int DMGRoll = Random.Range(2, 7);
        HPSystem.DMGTakenBoss = DMGRoll;
        BossPierced = 1;
        PierceDMG = 5;
        HPSystem.BossDef -= 3;
        TurnsSystem.BossTurn();
    }




    public void BossAttack()
    {
        if (BossStunned == 0)
        {
            if (BossCheck == 1)
            {

                int Diceroll = Random.Range(0, 3);
                if (Diceroll == 1)
                {

                    int DMGRoll = Random.Range(8, 13);
                    HPSystem.DMGTakenBoss = DMGRoll;
                }
                else if (Diceroll == 2)
                {

                }
                else
                {

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
        }

        if(BossPierced > 0)
        {
            BossPierced -= 1;
            HPSystem.DMGTakenBoss = PierceDMG;
            HPSystem.BossSliderUpdate();
        }
    }
}
