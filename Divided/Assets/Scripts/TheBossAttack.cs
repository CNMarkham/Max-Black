using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheBossAttack : MonoBehaviour
{
    public int AttackChoose;
    public GameObject BossWeakAttack;
    public GameObject BossOkayAttack;
    public GameObject BossStrongAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossRandomAttack()
    {
        int AttackChoose = Random.Range(0, 10);
        if (AttackChoose <= 2)
        {
            BossOkayAttack.SetActive(true);
            GetComponent<Animator>().SetTrigger("child2");
            HP.PlayerHPButReal -= 20;
        }
        else if (AttackChoose >= 3 && AttackChoose <= 5)
        {
            BossWeakAttack.SetActive(true);
            GetComponent<Animator>().SetTrigger("child3");
            HP.PlayerHPButReal -= 10;
        }
        else
        {
            BossStrongAttack.SetActive(true);
            GetComponent<Animator>().SetTrigger("child");
            HP.PlayerHPButReal -= 50;
        }
        HP.MoreUseful.HPBar.text = ("Player HP: " + HP.PlayerHPButReal);
        
        HP.MoreUseful.SlidyBoiPlayer.GetComponent<Image>().fillAmount = (float)HP.PlayerHPButReal / 1 * 0.01f;
    }


}
