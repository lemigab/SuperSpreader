using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SusMeter : MonoBehaviour
{
    public HealthBar healthBar;
    public string newGameScene;
    public static bool sus_isDead;
    public int maxHealth = 100;
    public int minHealth = 0;
    public static int currHealth;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = minHealth;
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(minHealth);
        sus_isDead = false;

    }

    //Update is called once per frame
    void Update()
    {
        if (currHealth >= maxHealth)
        {
            sus_isDead = true;

    
        }
        healthBar.setHealth(currHealth);
    }

    public bool checkDead()
    {
        return sus_isDead;
    }

    public void TakeDamage(int damage)
    {
        if (currHealth < maxHealth){
            currHealth += damage;
            healthBar.setHealth(currHealth);
        }
        
    }

    public void HealDamage(int damage)
    {
        if (currHealth > minHealth){
            currHealth -= damage;
            healthBar.setHealth(currHealth);
        }
        
    }
}
