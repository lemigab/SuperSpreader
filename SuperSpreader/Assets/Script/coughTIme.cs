using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coughTIme : MonoBehaviour
{
    public HealthBar healthBar;
    public bool isFull;
    public float maxHealth = 2.5f;
    public float minHealth = 0.0f;
    public static float currHealth;
    public CoughAttack cough;

   
    

    // Start is called before the first frame update
    void Start()
    {
        currHealth = minHealth;
        healthBar.setMaxHealthFloat(maxHealth);
        healthBar.setHealthFloat(currHealth);

        
    }

    //Update is called once per frame
    void Update()
    {
        healthBar.setHealthFloat(cough.attack_time);

        
        
        if(currHealth >= 0.0f){
            currHealth = maxHealth;
        }
    }



}
