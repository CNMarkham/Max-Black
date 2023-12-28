using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTheBoss : MonoBehaviour
{
    public GameObject Boss1;
    public GameObject Boss2;
    public GameObject Boss3;
    public int ChooseDaBoss;
    public int IfThirdBoss;
    // Start is called before the first frame update
    void Start()
    {
        int ChooseDaBoss = Random.Range(0, 3);
        int IfThirdBoss = Random.Range(0, 3);
        if(IfThirdBoss >= 1)
        {
            ChooseDaBoss += IfThirdBoss;
        }
        if(ChooseDaBoss >= 1)
        {
            Boss1.SetActive(true);

        } else if (ChooseDaBoss < 1 && ChooseDaBoss >= 2)
        {
            Boss2.SetActive(true);

        } else
        {
            Boss3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
