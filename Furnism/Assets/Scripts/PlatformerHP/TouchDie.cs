using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchDie : MonoBehaviour
{
    public PlayerMovement PMovement;

    //Find an object that had the PlayerMovement script
    private void Start()
    {
        PMovement = FindObjectOfType<PlayerMovement>();
    }

    //PlayerMovement immunity script but made to work on this script
    public void TDImmunity()
    {
        PMovement.DevMode = true;
        PMovement.GetComponent<SpriteRenderer>().color = (new Color(1,0.5f, 0.01f));
        PMovement.DevModeOnText.text = ("");
    }

    //PlayerMovement immunity off script but made to work on this script
    public void TDImmunityOff()
    {
        PMovement.DevMode = false;
        PMovement.DevModeOnText.text = ("");
    }

    //If DevMode is off and you touch a damaging object you die, if DevMode is on and you touch a damaging object it says in the debug log "Damage Nullified"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>().DevMode == false)
        {
            
            Lives.MainLives.Hearts -= 1;
            if (Lives.MainLives.Hearts == 0)
            {
                SceneManager.LoadScene(5);
            }
            Invoke("TDImmunityOff", 1f);
            TDImmunity();
        } else if(collision.gameObject.GetComponent<PlayerMovement>().DevMode == true)
        {
            Debug.Log("Damage Nullified");
        }
    }

    //Sends you back to the level you died at so you can play again
    public void PlayAgain()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelRespawnAt"));
    }
}
