using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRandomization : MonoBehaviour
{
    public GameObject Boss1;
    public GameObject Boss2;
    public GameObject Boss3;
    public int RandomizedBoss;
    // Start is called before the first frame update
    void Start()
    {
        int ChooseDaBoss = Random.Range(0, 9);
        if(ChooseDaBoss <= 3)
        {
            Boss1.SetActive(true);

        } else if (RandomizedBoss >= 4 && RandomizedBoss <= 6)
        {
            Boss2.SetActive(true);

        } else
        {
            Boss3.SetActive(true);
        }
    }
}
