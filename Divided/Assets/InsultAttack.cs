using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InsultAttack : MonoBehaviour
{
    public string[] ListOfInsults;
    public int INT;
    public TextMeshPro ME;
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
        INT = Random.Range(0, ListOfInsults.Length);
        ME.text = ListOfInsults[INT];
    }
}
