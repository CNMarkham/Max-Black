using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPSystem : MonoBehaviour
{
    public static HPSystem HpSystem;

    [Header("HP Number Vars")]
    public int PlayerHPNum;
    public int BossHPNum;
    public int PlayerHPNumMax;
    public int BossHPNumMax;


    public GameObject PlayerHpReference;
    public GameObject BossHpReference;
    public TextMeshProUGUI PlayerHPText;
    public TextMeshProUGUI BossHpBar;
    public GameObject PlayerHpSlider;
    public GameObject BossHpSlider;
    public GameObject ClassesHPSlider;
    public int DMGTaken;
    public int BossDef;
    public int PlayerDef;
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
            SceneManager.LoadScene(10);
        }
        if(PlayerHPNum > PlayerHPNumMax)
        {
            PlayerHPNum = PlayerHPNumMax;
        }
    }

    public void WarriorClass()
    {
        PlayerHPNumMax = 100;
    }
    public void MageClass()
    {
        PlayerHPNumMax = 70;
    }
    public void ArcherClass()
    {
        PlayerHPNumMax = 80;
    }

    public void PlayerAndCharacterHpSliderUpdate()
    {

        switch (GameManager.Classs2)
        {
            case GameManager.Classs.Warrior:
                PlayerHPNum = 100;
                break;
            case GameManager.Classs.Mage:
                PlayerHPNum = 70;
                ClassesHPSlider.GetComponent<Image>().fillAmount = (float)PlayerHPNum / 1 * 0.01f;
                break;
            case GameManager.Classs.Archer:
                PlayerHPNum = 85;
                ClassesHPSlider.GetComponent<Image>().fillAmount = (float)PlayerHPNum / 1 * 0.01f;
                break;
            default:
                break;
        } 
        PlayerHPText.text = ("Player HP: " + PlayerHPNum);
                PlayerHpSlider.GetComponent<Image>().fillAmount = (float)PlayerHPNum / 1 * 0.01f;
    }

    public void BossSliderUpdate()
    {
        BossHPNum -= DMGTaken - BossDef;
        HpSystem.BossHpBar.text = ("Boss HP: " + BossHPNum);
        HpSystem.BossHpSlider.GetComponent<Image>().fillAmount = (float)BossHPNum / 1 * 0.01f;
    }
}
