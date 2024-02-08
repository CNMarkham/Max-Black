using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttacking : MonoBehaviour
{
    public GameObject WarriorAttack;
    public GameObject MageAttack;
    public GameObject ArcherAttack;
    public HPSystem Hp;

    void Warrior()
    {
        WarriorAttack.SetActive(false);
        Hp.BossHpSliderUpdate(3);
    }

    void Mage()
    {
        MageAttack.SetActive(false);
        Hp.BossHpSliderUpdate(7);
    }

    void Archer()
    {
        ArcherAttack.SetActive(false);
        Hp.BossHpSliderUpdate(5);
    }
    public void QueueAttack()
    {

        switch (GameManager.Classs2)
        {
            case GameManager.Classs.Warrior:
                GetComponent<Animator>().SetTrigger("TriggerAnimationWarrior");
                WarriorAttack.SetActive(true);
                Invoke("Warrior", .42f);
                break;
            case GameManager.Classs.Mage:
                //CancelInvoke();
                GetComponent<Animator>().SetTrigger("TriggerAnimationMage");
                MageAttack.SetActive(true);
                Invoke("Mage", .42f);
                break;
            case GameManager.Classs.Archer:
                GetComponent<Animator>().SetTrigger("TriggerAnimationArcher");
                ArcherAttack.SetActive(true);
                Invoke("Archer", .42f);
                break;
            default:
                break;
        }
    }
}
