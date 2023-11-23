using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InsultAttack : MonoBehaviour
{
    public string[] ListOfInsults;
    public int chosenAttack;
    public TextMeshPro ME;
    public GameObject ThatChild;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame. 
    void Update()
    {
        
    }

    public void Something()
    {
       chosenAttack = Random.Range(0, ListOfInsults.Length);
        ME.text = ListOfInsults[chosenAttack];
        ThatChild.GetComponent<Animator>().SetTrigger("ThatChild");
        HP.ActuallyDoingStuff(Random.Range(0, 75));
    }
}
