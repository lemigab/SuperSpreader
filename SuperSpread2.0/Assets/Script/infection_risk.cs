using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infection_risk : MonoBehaviour
{
    
    private Renderer rend;
    private Color col = Color.red;
    public int infection_chance;

    public bool can_be_licked;

    public float lick_time;
    public float start_lick_time;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        can_be_licked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (lick_time <=0)
        {
            can_be_licked = true;
        }
        lick_time -= Time.deltaTime;
    }

    public void LickInfectionRisk()
    {
        if (can_be_licked == true)
        {
            infection_chance = Random.Range(1, 100);
            if (infection_chance < 101)
            {
                can_be_licked = false;
                Debug.Log("Damage");
                rend.material.color = col;
                lick_time = start_lick_time;
            }
        }
        
    }

    public void CoughInfectionRisk()
    {
        infection_chance = Random.Range(1, 100);
        if (infection_chance < 101)
        {
            Debug.Log("Damage");
            rend.material.color = col;
        }
    }

    public void SneezeInfectionRisk()
    {
        infection_chance = Random.Range(1, 100);
        if (infection_chance < 101)
        {
            Debug.Log("Damage");
            rend.material.color = col;
        }
    }


}
