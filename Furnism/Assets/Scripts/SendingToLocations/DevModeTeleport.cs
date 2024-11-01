using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevModeTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerMovement>().transform.position = new Vector3(1f, 1f);
    }


}
