using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnL3 : MonoBehaviour
{
    public SceneMovers SM;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SM.LevelToRespawnAt = 4;
    }
}
