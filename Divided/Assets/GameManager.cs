using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Classs { Warrior, Mage, Archer }
    public static Classs Classs2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetClass(int classToChange)
    {
        Classs2 = (Classs)classToChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        switch (Classs2)
        {
            case Classs.Warrior:

                break;
            case Classs.Mage:
                break;
            case Classs.Archer:
                break;
            default:
                break;
        }
    }
}
