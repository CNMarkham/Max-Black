using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPSystem : MonoBehaviour
{
    public static HPSystem HpSystem;
    public GameObject PlayerHpReferance;
    public GameObject BossHpReferance;
    public int PlayerHpInt;
    public int BossHpInt;
    public TextMeshProUGUI PlayerHpBar;
    public TextMeshProUGUI BossHpBar;
    public GameObject PlayerHpSlider;
    public GameObject BossHpSlider;
    public GameObject CharacterHpSlider;
    void Start()
    {
        PlayerHpInt = 100;
        HpSystem = this;
        BossHpInt = 100;
    }

    void Update()
    {
        if (PlayerHpInt <= 0)
        {
            SceneManager.LoadScene(10);
        }
    }

    public void PlayerAndCharacterHpSliderUpdate()
    {

        switch (GameManager.Classs2)
        {
            case GameManager.Classs.Warrior:
                PlayerHpInt = 100;
                break;
            case GameManager.Classs.Mage:
                PlayerHpInt = 70;
                CharacterHpSlider.GetComponent<Image>().fillAmount = (float)PlayerHpInt / 1 * 0.01f;
                break;
            case GameManager.Classs.Archer:
                PlayerHpInt = 85;
                CharacterHpSlider.GetComponent<Image>().fillAmount = (float)PlayerHpInt / 1 * 0.01f;
                break;
            default:
                break;
        } 
        PlayerHpBar.text = ("Player HP: " + PlayerHpInt);
                PlayerHpSlider.GetComponent<Image>().fillAmount = (float)PlayerHpInt / 1 * 0.01f;
    }

    public void BossHpSliderUpdate(int damage)
    {
        BossHpInt -= damage;
        HpSystem.BossHpBar.text = ("Boss HP: " + BossHpInt);
        HpSystem.BossHpSlider.GetComponent<Image>().fillAmount = (float)BossHpInt / 1 * 0.01f;
    }

    public void FinalBossHpSliderUpdate(int damage)
    {
        BossHpInt = damage;
        HpSystem.BossHpBar.text = ("Boss HP: " + BossHpInt);
        HpSystem.BossHpSlider.GetComponent<Image>().fillAmount = (float)BossHpInt / 1 * 0.01f;
    }
}
