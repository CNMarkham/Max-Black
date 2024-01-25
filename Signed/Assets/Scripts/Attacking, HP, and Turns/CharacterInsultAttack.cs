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
    public void Something()
    {
        ChosenAttack = Random.Range(0, ListOfInsults.Length);
        InsultTexts.text = ListOfInsults[ChosenAttack];
        InsultAttackAnimation.GetComponent<Animator>().SetTrigger("ThatChild");
        Hp.BossHpSliderUpdate(Random.Range(0, 47));
    }
}
