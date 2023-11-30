using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed2 = 2.0f;
	public GameObject character;
	public bool isGrounded;
	public float JumpHold;
    void Update()
	{

		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed2 * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed2 * Time.deltaTime;

		}
		GetComponent<Animator>().SetFloat("Hinput", Input.GetAxis("Horizontal"));
        if (Input.GetKey(KeyCode.Z))
        {
			JumpHold  += 0.1f;
			if(JumpHold >= 10f)
            {	
				JumpHold = 10f;
            }

		

		}
        if (Input.GetKeyUp(KeyCode.Z))
		{
			GetComponent<Animator>().SetBool("To Air or Not To Air? ", true);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpHold * 50));
			JumpHold = 0f;
			
		}
	}
}

