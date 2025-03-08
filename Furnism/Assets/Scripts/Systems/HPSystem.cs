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

    //Sets the player and bosses HP and maximum HP to 100, tells references to this script that this is HpSystem, sets both the player and the bosses stun counts to zero, sets the variables that check if the player or boss is buffed to false, and updates the player and the bosses HP bars
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
        //Checks if the players HP is less than 0, if it is it sends you to the death screen
        if (PlayerHPNum <= 0)
        {
            SceneManager.LoadScene(5);
            SM.LevelToRespawnAt = 1;
        }

        //Checks if the bosses HP is less than 0, if it is it sends you to the win screen
        if (BossHPNum <= 0)
        {
            SceneManager.LoadScene(6);
        }

        //Checks if at any point the player has more HP than their max HP then it sets their HP to their maximum HP
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

    //If you click the Warrior class it sets your max HP to 100, your HP to 100, your defense to 0, ClassCheck to 1, and updates the players and the bosses HP bars
    public void WarriorClass()
    {
        PlayerHPNumMax = 100;
        PlayerHPNum = 100;
        PlayerDef = 0;
        TurnsSystem.ClassCheck = 1;
        PlayerSliderUpdate();
        BossSliderUpdate();
    }

    //If you click the Mage class it sets your max HP to 70, your HP to 70, your defense to 0, ClassCheck to 2, and updates the players and the bosses HP bars
    public void MageClass()
    {
        PlayerHPNumMax = 70;
        PlayerHPNum = 70;
        PlayerDef = 0;
        TurnsSystem.ClassCheck = 2;
        PlayerSliderUpdate();
        BossSliderUpdate();
    }

    //If you click the Archer class it sets your max HP to 85, your HP to 85, your defense to 0, ClassCheck to 3, and updates the players and the bosses HP bars
    public void ArcherClass()
    {
        PlayerHPNumMax = 80;
        PlayerHPNum = 80;
        PlayerDef = 0;
        TurnsSystem.ClassCheck = 3;
        PlayerSliderUpdate();
        BossSliderUpdate();
    }
    
    //Updates the players HP bar
    public void PlayerSliderUpdate()
    {
        //If the damage the player would've taken is less than the amount of defense the player has the player takes 0 damage
        if(DMGTakenPlayer < PlayerDef)
        {
            DMGTakenPlayer = 0;
        } else if (DMGTakenPlayer > PlayerDef){
            DMGTakenPlayer = DMGTakenPlayer - PlayerDef;
        }
        //Takes away the players HP for how much they should take from the attack, sets the players HP bar to say "Player HP: (Whatever HP they should be at) ", then sets the HP bars slider to whatever it should be at, and lastly sets the players defense text to their defense amount
        PlayerHPNum -= DMGTakenPlayer;
        PlayerHPSliderText.text = ("Player HP: " + PlayerHPNum);
        if(TurnsSystem.ClassCheck == 1)
        {
            PlayerHPSlider.GetComponent<Slider>().value = (float)PlayerHPNum / 1 * 0.01f;
        }
        if (TurnsSystem.ClassCheck == 2)
        {
            PlayerHPSlider.GetComponent<Slider>().value = (float)PlayerHPNum / 1 * 0.017f;
        }
        if (TurnsSystem.ClassCheck == 3)
        {
            PlayerHPSlider.GetComponent<Slider>().value = (float)PlayerHPNum / 1 * 0.018f;
        }
        PlayerDefText.text = (PlayerDef.ToString());
        DeathCheck();
    }

    //Updates the bosses HP bar
    public void BossSliderUpdate()
    {
        //If the damage the boss would've taken is less than the amount of defense the boss has the boss takes 0 damage
        if (DMGTakenBoss < BossDef)
        {
            DMGTakenBoss = 0;
        } else if(DMGTakenBoss > BossDef){
            DMGTakenBoss = DMGTakenBoss - BossDef;
        }

        //Takes away the bosses HP for how much they should take from the attack, sets the bosses HP bar to say "Boss HP: (Whatever HP they should be at) ", then sets the HP bars slider to whatever it should be at, and lastly sets the bosses defense text to their defense amount
        BossHPNum -= DMGTakenBoss;
        BossHPSliderText.text = ("Boss HP: " + BossHPNum);
        BossHPSlider.GetComponent<Slider>().value = (float)BossHPNum / 1 * 0.01f;
        BossDefText.text = (BossDef.ToString());
        DeathCheck();
    }
}
