using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            //for (int i = 0; i < 2000; i++)
            //{
            //    anim.SetBool("idle_up", true);
            //    anim.SetBool("walking_up", false);
            //    anim.SetBool("walking_down", false);
            //    anim.SetBool("walking_right", false);
            //    anim.SetBool("idle_right", false);
            //    anim.SetBool("idle_down", false);
            //}
            //for (int i = 0; i < 2000; i++)
            //{
            //    anim.SetBool("idle_down", true);
            //    anim.SetBool("walking_up", false);
            //    anim.SetBool("walking_down", false);
            //    anim.SetBool("walking_right", false);
            //    anim.SetBool("idle_right", false);
            //    anim.SetBool("idle_up", false);
            //    Debug.Log("hello");
            //}
            SusMeter.currHealth -= 5;
            PartyMeter.currHealth += 10;
            
        }
    }
}
