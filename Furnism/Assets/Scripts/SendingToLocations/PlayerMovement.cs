using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Speeds")]
	public float Speed = 6.5f;

	[Header("Jumping Tools")]
	public int JumpsLeft;
	public bool isGrounded;
	public float JumpHold;

	[Header("LayerMask")]
	public LayerMask lPayerMask;

    public void Start()
    {
		JumpsLeft = 2;
    }
    void Update()
	{

			if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * Speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * Speed * Time.deltaTime;

		}
		GetComponent<Animator>().SetFloat("H-Input", Input.GetAxis("Horizontal"));
        if (Input.GetKey(KeyCode.Z))
        {
			JumpHold  += 0.1f;
			if(JumpHold >= 6f)
            {	
				JumpHold = 6f;
            }

		

		}

		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, (float)0.8, lPayerMask);
		if (hit.collider != null)
		{
			isGrounded = true;
			JumpsLeft = 2;
			//GetComponent<Animator>().SetTrigger("TriggerJump");
		}
		else
		{
			//GetComponent<Animator>().SetTrigger("TriggerJump");
		}
		if (Input.GetKeyUp(KeyCode.Z) && isGrounded == true && JumpsLeft >= 1)
		{
			isGrounded = false;
			JumpsLeft -= 1;
			GetComponent<Animator>().SetTrigger("TriggerJump");
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpHold * 50));
			JumpHold = 1f;
			
		}
		
	}
}

