using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = (((int)(t / 60)+10) % 12).ToString();
        string seconds = (t % 60).ToString("f0");

        if (minutes.Length == 1)
        {
            minutes = "0" + minutes;
        }
        if (seconds.Length == 1)
        {
            seconds = "0" + seconds;
        }
       
        timerText.text = minutes + ":" + seconds;
    }
}
