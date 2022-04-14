using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    Text score_text;
    

    public SusMeter sus;
    public PartyMeter party;

    public static int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        score_text = GetComponent<Text>();
        score_text.text = "Score: ";
        score = 0;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = "Score: " + score;

        
    }
    public void AddScore()
    {
        

    }
}
