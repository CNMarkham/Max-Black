using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerMovement : MonoBehaviour
{
    public float speedForStalker = 2.99f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speedForStalker * Time.deltaTime;
    }
}
