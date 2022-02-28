using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoughAttack : MonoBehaviour
{

    public float attack_time;

    // Time between attacks
    public float start_time;

    public Transform infect_pos;
    public float infect_range;
    public LayerMask enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if c pressed find all enemies in range and infect them
        if (attack_time <= 0)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Collider2D[] enemy_to_infect = Physics2D.OverlapCircleAll(infect_pos.position, infect_range, enemies);
                for (int i = 0; i < enemy_to_infect.Length; i++)
                {
                    enemy_to_infect[i].GetComponent<infection_risk>().CoughInfectionRisk();
                }
                attack_time = start_time;


            }

        }
        attack_time -= Time.deltaTime;

    }


    // Visualization of cough circle size
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(infect_pos.position, infect_range);
    }
}
