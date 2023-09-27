using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToMoveForDummies : MonoBehaviour
{
    public float moveSpeed = 5;
    public SpriteRenderer PlayerRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right *moveSpeed * Time.deltaTime;
            PlayerRenderer.flipX = true;

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left *moveSpeed * Time.deltaTime;
            PlayerRenderer.flipX = false;

        }

        //else if (Input.GetKey(KeyCode.W))
        //{
            //transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
            //transform.position += Vector3.up * -moveSpeed * Time.deltaTime;

        //}
    }
}
