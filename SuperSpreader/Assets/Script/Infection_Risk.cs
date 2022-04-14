using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infection_Risk : MonoBehaviour
{
    
    private Renderer rend;
    private Color col_red = Color.red;
    private Color col_green = Color.green;
    private Color col_blue = Color.blue;
    private int infection_chance;
   
    public bool can_be_licked;
    public Text ScoreText;


   // public GameObject Enemy;
    public float lick_time;
    public float start_lick_time;

    public float sneeze_time;
    public float start_sneeze_time;

    public SusMeter sus;

    private bool is_infected;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        is_infected = false;
        //can_be_licked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            //Debug.Log(GameObject.layer.ToString);
        }
        if (lick_time <= 0)
        {
            can_be_licked = true;
        }
        lick_time -= Time.deltaTime;
        sneeze_time -= Time.deltaTime;
    }

    public void LickInfectionRisk()
    {
        if (can_be_licked == true)
        {
            if (is_infected == false)
            {
                infection_chance = Random.Range(1, 100);
                if (infection_chance % 2 == 0)
                {
                    can_be_licked = false;
                    Debug.Log("Damage");


                    rend.material.color = col_red;
                    lick_time = start_lick_time;
                    Score.score += 1;
                    SusMeter.currHealth += 15;
                    is_infected = true;
                }
            }
        }

        

    }

    public void CoughInfectionRisk()
    {
        if (is_infected == false)
        {
            infection_chance = Random.Range(1, 100);
            if (infection_chance %2 == 0)
            {
                rend.material.color = col_red;
                Debug.Log("Damage");
                Score.score += 1; // Adds to sus meter if infected
                is_infected = true;


            }
        }
        SusMeter.currHealth += 20;
    }

    public void SneezeInfectionRisk()
    {
        if (is_infected == false)
        {

            infection_chance = Random.Range(1, 100);
            if (infection_chance % 2 == 0)
            {
                Debug.Log("Damage");
                rend.material.color = col_red;
                sneeze_time = start_sneeze_time;
                Score.score += 1;               
                is_infected = true;

            }
        }
        SusMeter.currHealth += 10;
    }


  


}
