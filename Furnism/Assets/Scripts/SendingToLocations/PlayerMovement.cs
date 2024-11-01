using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	[Header("Speeds")]
	public float Speed = 6.5f;

	[Header("Jumping Tools")]
	public int JumpsLeft;
	public bool isGrounded;
	public float JumpHold;
	public bool DevMode;

	[Header("LayerMask")]
	public LayerMask lPayerMask;

	public Slider jumpSlider;

    public void Start()
    {
		DevMode = false;
    }
    
	void Update()
	{

		//When you click the Right Arrow Key you move right
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * Speed * Time.deltaTime;
		
		}

		//When you click the Left Arrow Key you move left
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * Speed * Time.deltaTime;

		}

		//Sends float values to the Animator when you move Left or Right
		GetComponent<Animator>().SetFloat("H-Input", Input.GetAxis("Horizontal"));
        

		//Jump, when you click the Z Key, it will also make you jump higher the longer you hold Z 
		if (Input.GetKey(KeyCode.Z))
        {
			JumpHold  += 4 * Time.deltaTime;
			if(JumpHold >= 6f)
            {	
				JumpHold = 6f;
            }


		}

		//Checks when you are on the ground and when you are not, if you are then it gives you your jumps back
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, (float)0.8, lPayerMask);
		if (hit.collider != null)
		{
			isGrounded = true;
		}

		//Checks if your are or aren't on the ground if you are and you have clicked and lifted your finger off the Z key it jumps
		if (Input.GetKeyUp(KeyCode.Z) && isGrounded == true)
		{
			isGrounded = false;
			GetComponent<Animator>().SetTrigger("TriggerJump");
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpHold * 65));
			JumpHold = 1f;
		}
		jumpSlider.value = JumpHold;


		//If you have clicked and lifted your finger off the P key it activates DevMode
		if (Input.GetKeyUp(KeyCode.P))
        {
			DevMode = true;
        };
	}
}

