using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LickAttack : MonoBehaviour
{



    public float attack_time;
    public float start_time;

    public Transform infect_pos;
    public LayerMask enemies;

    private Renderer rend;

    public float stick_time;
    public float start_stick_time;
    public Vector2 lick_size;



    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.sortingLayerName = "Behind";


    }

    // Update is called once per frame
    void Update()
    { 

        if (attack_time <= 0)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {

                transform.position = infect_pos.position;
                rend.sortingLayerName = "Floor";
                attack_time = start_time;
                stick_time = start_stick_time;



            }
            
        }
        if (stick_time <= 0)
        {
            rend.sortingLayerName = "Behind";
        }
        if (rend.sortingLayerName == "Floor") 
        {
            Collider2D[] lick_infect = Physics2D.OverlapBoxAll(transform.position, lick_size, enemies);
            for (int i = 0; i < lick_infect.Length; i++)
            {
                lick_infect[i].GetComponent<infection_risk>().LickInfectionRisk();
            }
        }
        stick_time -= Time.deltaTime;
        attack_time -= Time.deltaTime;
        
    }

    public void infect()
    {
        if (rend.sortingLayerName == "Floor")
        {
            Collider2D[] lick_infect = Physics2D.OverlapBoxAll(transform.position, lick_size, enemies);
            for (int i = 0; i < lick_infect.Length; i++)
            {
                if (lick_infect[i].GetComponent<infection_risk>().can_be_licked == true)
                {
                    lick_infect[i].GetComponent<infection_risk>().LickInfectionRisk();
                }
            }
        }
    }
}


