using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttacking : MonoBehaviour
{
    public int RandomAttack;
    public GameObject WeakAttack;
    public GameObject MidAttack;
    public GameObject StrongAttack;
    public HPSystem Hp;

    public void RandomizedAttack()
    {
        int RandomAttack = Random.Range(0, 10);
        if (RandomAttack <= 3)
        {
            MidAttack.SetActive(true);
            GetComponent<Animator>().SetTrigger("child2");
            Hp.PlayerHpInt -= 20;
        }
        else if (RandomAttack >= 4 && RandomAttack <= 8)
        {
            WeakAttack.SetActive(true);
            GetComponent<Animator>().SetTrigger("child3");
            Hp.PlayerHpInt -= 10;
        }
        else if (RandomAttack >= 9 && RandomAttack <= 10)
        {
            StrongAttack.SetActive(true);
            GetComponent<Animator>().SetTrigger("child");
            Hp.PlayerHpInt -= 50;
        }
        HPSystem.HpSystem.PlayerHpBar.text = ("Player HP: " + Hp.PlayerHpInt);
        
        HPSystem.HpSystem.PlayerHpSlider.GetComponent<Image>().fillAmount = (float)Hp.PlayerHpInt / 1 * 0.01f;
    }


}
