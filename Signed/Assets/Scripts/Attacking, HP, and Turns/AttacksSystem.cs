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

    [Header("Player Vars")]
    public int DMGRoll;
    // Start is called before the first frame update

    public void TennisBallThrow()
    {
        GetComponent<Animator>().SetTrigger("1stAttack");
        int DMGRoll = Random.Range(7, 10);
        HPSystem.DMGTaken = DMGRoll;

    }
    public void SpinAttack()
    {
        HPSystem.PlayerDef += 2;
    }
    public void DisrespectfulSlap()
    {

    }




    public void Fireball()
    {

    }
    public void HealSpell()
    {

    }
    public void FlyingSwords()
    {

    }




    public void SpiritArrow()
    {

    }
    public void FallenArrow()
    {

    }
    public void ArrowRain()
    {

    }




    private void Update()
    {
        if(BossCheck == 1)
        {
            int Diceroll = Random.Range(0, 3);
            if(Diceroll == 1)
            {

            } else if(Diceroll == 2)
            {

            } else
            {

            }
        } else if(BossCheck == 2)
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
        } else
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
    }
}
