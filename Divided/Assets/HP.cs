using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public static HP MoreUseful;
    public GameObject PlayerHP;
    public GameObject EnemyHP;
    public static int PlayerHPButReal;
    public static int EnemyHPButReal;
    public TextMeshProUGUI HPBar;
    public TextMeshProUGUI BossHPBar;
    public GameObject SlidyBoiPlayer;
    public GameObject SlidyBoiEnemy;
    // Start is called before the first frame update
    void Start()
    {
        MoreUseful = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HPChangeCuzClassesBoiiii()
    {
        switch (GameManager.Classs2)
        {
            case GameManager.Classs.Warrior:
                PlayerHPButReal = 100;
                break;
            case GameManager.Classs.Mage:
                PlayerHPButReal = 70;
                break;
            case GameManager.Classs.Archer:
                PlayerHPButReal = 85;
                break;
            default:
                break;
        } 
        HPBar.text = ("Player HP: " + PlayerHPButReal);
                SlidyBoiPlayer.GetComponent<Image>().fillAmount = (float)PlayerHPButReal / 1 * 0.01f;
    }

    public static void ActuallyDoingStuff(int damage)
    {
        EnemyHPButReal -= damage;
        MoreUseful.BossHPBar.text = ("Boss HP: " + EnemyHPButReal);
        MoreUseful.SlidyBoiEnemy.GetComponent<Image>().fillAmount = (float)EnemyHPButReal / 1 * 0.01f;
    }
}
