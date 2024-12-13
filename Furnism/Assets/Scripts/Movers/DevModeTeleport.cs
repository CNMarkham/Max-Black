using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevModeTeleport : MonoBehaviour
{
    //Finds a player movement script and makes a new vector at a position
    void Start()
    {
        FindObjectOfType<PlayerMovement>().transform.position = new Vector3(1f, 1f);
    }
}
