using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchDie : MonoBehaviour
{
    public GameObject Player;
    public PlayerMovement PlayerMoveScript;

    //If DevMode is off and you touch a damaging object you die, if DevMode is on and you touch a damaging object it says in the debug log "Damage Nullified"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>().DevMode == false)
        {
            SceneManager.LoadScene(5);
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
