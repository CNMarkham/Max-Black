using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterInsultAttack : MonoBehaviour
{
    public string[] ListOfInsults;
    public int ChosenAttack;
    public TextMeshPro InsultTexts;
    public GameObject InsultAttackAnimation;
    public HPSystem Hp;
    public void TriggerInsultAttack()
    {
        ChosenAttack = Random.Range(0, ListOfInsults.Length);
        InsultTexts.text = ListOfInsults[ChosenAttack];
        InsultAttackAnimation.GetComponent<Animator>().SetTrigger("TriggerAnimationInsultAttack");
        Hp.BossSliderUpdate(Random.Range(0, 25));
        Invoke("Disappear", 1f);
    }  
    public void Disappear()
    {
        gameObject.SetActive(false);
    }
}
