using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	public float speed2 = 3.0f;
	public GameObject character;
	public bool isGrounded;
	public float JumpHold;
	public LayerMask lPayerMask;
    void Update()
	{

        if (Input.GetKey(KeyCode.C))
        {

			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		

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
			if(JumpHold >= 6f)
            {	
				JumpHold = 6f;
            }

		

		}
        if (Input.GetKeyUp(KeyCode.Z))
		{
			GetComponent<Animator>().SetBool("To Air or Not To Air? ", true);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpHold * 50));
			isGrounded = false;
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

