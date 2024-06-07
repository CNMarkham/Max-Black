using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPSystem : MonoBehaviour
{
    [Header("Other Script References")]
    public static HPSystem HpSystem;
    public TurnsSystem TurnsSystem;

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
    void Start()
    {
        PlayerHPNum = 100;
        BossHPNum = 100;
        HpSystem = this;
    }

    void Update()
    {
        if (PlayerHPNum <= 0)
        {
            //SceneManager.LoadScene(10);
        }
        if(PlayerHPNum > PlayerHPNumMax)
        {
            PlayerHPNum = PlayerHPNumMax;
        }
    }

    public void WarriorClass()
    {
        PlayerHPNumMax = 100;
        PlayerHPNum = 100;
        PlayerDef = 0;
        TurnsSystem.ClassCheck = 1;
    }
    public void MageClass()
    {
        PlayerHPNumMax = 70;
        PlayerHPNum = 70;
        PlayerDef = 0;
        TurnsSystem.ClassCheck = 2;
    }
    public void ArcherClass()
    {
        PlayerHPNumMax = 80;
        PlayerHPNum = 80;
        PlayerDef = 0;
        TurnsSystem.ClassCheck = 3;
    }
    
    public void PlayerSliderUpdate()
    {
        PlayerHPNum -= DMGTakenPlayer - PlayerDef;
        PlayerHPSliderText.text = ("Player HP: " + PlayerHPNum);
        PlayerHPSlider.GetComponent<Image>().fillAmount = (float)PlayerHPNum / 1 * 0.01f;
        PlayerDefText.text = (PlayerDef.ToString());
    }

    public void BossSliderUpdate()
    {
        BossHPNum -= DMGTakenBoss - BossDef;
        HpSystem.BossHPSliderText.text = ("Boss HP: " + BossHPNum);
        HpSystem.BossHPSlider.GetComponent<Image>().fillAmount = (float)BossHPNum / 1 * 0.01f;
        BossDefText.text = (BossDefText.ToString());
    }
}
