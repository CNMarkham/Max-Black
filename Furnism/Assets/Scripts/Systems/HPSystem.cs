using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class HPSystem : MonoBehaviour
{
    [Header("Other Script References")]
    public static HPSystem HpSystem;
    public TurnsSystem TurnsSystem;
    public AttacksSystem AttacksSystem;
    public SceneMovers SM;

    [Header("HP Number Vars")]
    public int PlayerHPNum;
    public int BossHPNum;
    public int PlayerHPNumMax;
    public int BossHPNumMax;

    [Header("Slider Text")]
    public TextMeshProUGUI PlayerHPSliderText;
    public TextMeshProUGUI BossHPSliderText;

    [Header("Physical Sliders")]
    public GameObject PlayerHPSlider;
    public GameObject BossHPSlider;

    [Header("DMG Taken")]
    public int DMGTakenBoss;
    public int DMGTakenPlayer;

    [Header("Def Vars")]
    public int BossDef;
    public int PlayerDef;
    public TextMeshProUGUI BossDefText;
    public TextMeshProUGUI PlayerDefText;

    //Sets all variables to what they need to be at the start of the game.
    void Start()
    {
        BossHPNumMax = 100;
        PlayerHPNum = 1;
        PlayerHPNumMax = 1;
        BossHPNum = 100;
        HpSystem = this;
        PlayerDef = 0;
        BossDef = 0;
        AttacksSystem.PlayerStunned = false;
        AttacksSystem.BossStunned = false;
        AttacksSystem.PlayerBuffed = false;
        AttacksSystem.BossBuffed = false;
    }

    public void DeathCheck()
    {
        //If the player ever has less than 0 Hp you get sent to the death screen.
        if (PlayerHPNum <= 0)
        {
            SceneManager.LoadScene(8);
        }

        //If the boss every has less than 0 Hp you get sent to the win screen.
        if (BossHPNum <= 0)
        {
            SceneManager.LoadScene(6);
        }

        //If either the player or boss has more than their max Hp set their Hp to their max Hp.
        if (PlayerHPNum > PlayerHPNumMax)
        {
            PlayerHPNum = PlayerHPNumMax;
            DMGTakenPlayer = 0;
            PlayerSliderUpdate();
        }
        if (BossHPNum > BossHPNumMax)
        {
            BossHPNum = BossHPNumMax;
            DMGTakenBoss = 0;
            BossSliderUpdate();
        }
    }

    //Sets the variables to what they need to be for the Warrior class.
    public void WarriorClass()
    {
        PlayerHPNumMax = 100;
        PlayerHPNum = 100;
        PlayerDef = 0;
        TurnsSystem.ClassCheck = 1;
        PlayerSliderUpdate();
        BossSliderUpdate();
    }

    //Sets the variables to what they need to be for the Mage class.
    public void MageClass()
    {
        PlayerHPNumMax = 70;
        PlayerHPNum = 70;
        PlayerDef = 0;
        TurnsSystem.ClassCheck = 2;
        PlayerSliderUpdate();
        BossSliderUpdate();
    }

    //Sets the variables to what they need to be for the Archer class.
    public void ArcherClass()
    {
        PlayerHPNumMax = 80;
        PlayerHPNum = 80;
        PlayerDef = 0;
        TurnsSystem.ClassCheck = 3;
        PlayerSliderUpdate();
        BossSliderUpdate();
    }
    
    //Updates the players HP bar.
    public void PlayerSliderUpdate()
    {
        if(DMGTakenPlayer < PlayerDef)
        {
            DMGTakenPlayer = 0;
        } else if (DMGTakenPlayer > PlayerDef){
            DMGTakenPlayer = DMGTakenPlayer - PlayerDef;
        }
        PlayerHPNum -= DMGTakenPlayer;
        PlayerHPSliderText.text = ("Player HP: " + PlayerHPNum);
        if(TurnsSystem.ClassCheck == 1)
        {
            PlayerHPSlider.GetComponent<Slider>().value = (float)PlayerHPNum / 1 * 0.01f;
        }
        if (TurnsSystem.ClassCheck == 2)
        {
            PlayerHPSlider.GetComponent<Slider>().value = (float)PlayerHPNum / 1 * 0.0175f;
        }
        if (TurnsSystem.ClassCheck == 3)
        {
            PlayerHPSlider.GetComponent<Slider>().value = (float)PlayerHPNum / 1 * 0.018f;
        }
        PlayerDefText.text = (PlayerDef.ToString());
        DeathCheck();
    }

    //Updates the bosses HP bar.
    public void BossSliderUpdate()
    {
        if (DMGTakenBoss < BossDef)
        {
            DMGTakenBoss = 0;
        } else if(DMGTakenBoss > BossDef){
            DMGTakenBoss = DMGTakenBoss - BossDef;
        }
        BossHPNum -= DMGTakenBoss;
        BossHPSliderText.text = ("Boss HP: " + BossHPNum);
        BossHPSlider.GetComponent<Slider>().value = (float)BossHPNum / 1 * 0.01f;
        BossDefText.text = (BossDef.ToString());
        DeathCheck();
    }
}
