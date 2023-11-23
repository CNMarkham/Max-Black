using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Thing3;
    public GameObject Thing2;
    public GameObject Thing;
    public GameObject ThatChild;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Warrior()
    {
        Thing3.SetActive(false);
        HP.ActuallyDoingStuff(3);
    }

    void Mage()
    {
        Thing2.SetActive(false);
        HP.ActuallyDoingStuff(7);
    }

    void Archer()
    {
        Thing.SetActive(false);
        HP.ActuallyDoingStuff(5);
    }


    public void Attackk()
    {

        switch (GameManager.Classs2)
        {
            case GameManager.Classs.Warrior:
                GetComponent<Animator>().SetTrigger("Child3");
                Thing3.SetActive(true);
                Invoke("Warrior", .42f);
                break;
            case GameManager.Classs.Mage:
                //CancelInvoke();
                GetComponent<Animator>().SetTrigger("Child2");
                Thing2.SetActive(true);
                Invoke("Mage", .42f);
                break;
            case GameManager.Classs.Archer:
                GetComponent<Animator>().SetTrigger("Child");
                Thing.SetActive(true);
                Invoke("Archer", .42f);
                break;
            default:
                break;
        }
    }
}
