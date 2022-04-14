using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    Text end_score_text;
    public static int end_score = 0;
    // Start is called before the first frame update
    void Start()
    {
        end_score_text = GetComponent<Text>();
        end_score_text.text = "Score: ";
        end_score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        end_score = Score.score;
       
        end_score_text.text = "Score: " + end_score;
    }
}
