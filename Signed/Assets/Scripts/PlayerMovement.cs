using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Speeds")]
	public float speed = 6f;
	public float Speed2 = 3.0f;
	
	[Header("Jumping Tools")]
	public bool isGrounded;
	public float JumpHold;

	[Header("LayerMask")]
	public LayerMask lPayerMask;
	void Update()
	{

			if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * Speed2 * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * Speed2 * Time.deltaTime;

		}
		GetComponent<Animator>().SetFloat("Hinput", Input.GetAxis("Horizontal"));
        if (Input.GetKey(KeyCode.Z))
        {
			JumpHold  += 0.1f;
			if(JumpHold >= 6f)
            {	
				JumpHold = 6f;
            }

		

		}
		if (Input.GetKeyUp(KeyCode.Z) && isGrounded == true)
		{
			isGrounded = false;
			GetComponent<Animator>().SetBool("To Air or Not To Air? ", true);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpHold * 50));
            if (CompareTag("Floor"))
            {
				isGrounded = true;
            }
			JumpHold = 0f;
			
		}

		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 2.33f, lPayerMask);
		if (hit.collider != null)
		{
			isGrounded = true;
			GetComponent<Animator>().SetBool("To Air or Not To Air? ", false);
        }
        else
        {
			GetComponent<Animator>().SetBool("To Air or Not To Air? ", true);
		}
	}
}

