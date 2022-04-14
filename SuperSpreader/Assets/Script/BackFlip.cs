using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFlip : MonoBehaviour
{


    public float attack_time;
    public SusMeter sus;
    public PartyMeter party;
    // Time between attacks
    public float start_time;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        anim.SetBool("flipping",false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attack_time <= 0)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
           
                anim.SetBool("flipping",true);
                SusMeter.currHealth -= 5;
                PartyMeter.currHealth += 20;
                attack_time = start_time;




            }
            //need to change this to "if ! any key besides w a s d"
            if (Input.GetKey(KeyCode.W))
        {
           anim.SetBool("flipping",false);

        }

        // When S key pressed move down and start walking down animation
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("flipping",false);

        }

        // When A key pressed move lef and start walking right animation
        if (Input.GetKey(KeyCode.A))
        {
            
            anim.SetBool("flipping",false);
        }

        // When A key pressed move right and start walking right animation
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("flipping",false);

        }
       
            if (!Input.anyKey){
            anim.SetBool("flipping",false);
        
    
        
        }
    
        }
        attack_time -= Time.deltaTime;
        
    }
}
