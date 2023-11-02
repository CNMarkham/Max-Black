using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
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
        int AttackChoose = Random.Range(1, 10);
        if (AttackChoose >= 6)
        {
            BossStrongAttack.SetActive(true);
            GetComponent<Animator>().SetTrigger("child");
            
        }
        else if (AttackChoose <= 7 && AttackChoose >= 9)
        {
            BossStrongAttack.SetActive(true);
            GetComponent<Animator>().SetTrigger("child");
        }
        else
        {
            BossStrongAttack.SetActive(true);
            GetComponent<Animator>().SetTrigger("child");
        }
    }
}
