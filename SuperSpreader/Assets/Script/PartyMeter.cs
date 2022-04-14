using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMeter : MonoBehaviour
{
    public HealthBar healthBar;
    public static bool party_isDead;
    public int maxHealth = 100;
    public int minHealth = 0;
    public static int currHealth;

    public float down_time;
    

    // Start is called before the first frame update
    void Start()
    {
        currHealth = minHealth;
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(currHealth);
        party_isDead = false;
        down_time = 2;
    }

    //Update is called once per frame
    void Update()
    {
        if (currHealth >= maxHealth)
        {
            party_isDead = true;
        }
        healthBar.setHealth(currHealth);

        if (down_time <= 0)
        {
            currHealth -= 5;
            down_time = 2;
        }
        down_time -= Time.deltaTime;
        if(currHealth < minHealth){
            currHealth = minHealth;
        }
    }

    public bool checkDead()
    {
        return party_isDead;
    }

    public void TakeParty(int damage)
    {
        if (currHealth < maxHealth)
        {
            currHealth += damage;
            healthBar.setHealth(currHealth);
        }

    }

    public void HealParty(int damage)
    {
        if (currHealth > minHealth)
        {
            currHealth -= damage;
            healthBar.setHealth(currHealth);
        }

    }
}
