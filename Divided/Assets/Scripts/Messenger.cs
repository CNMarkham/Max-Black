using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Messenger : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimerUI();
        DontDestroyOnLoad(this);
    }

    void UpdateTimerUI()
    {
        secondsCount += Time.deltaTime;
        timerText.text = hourCount + "H:" + minuteCount + "M:" + (int)secondsCount + "S";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }
}
