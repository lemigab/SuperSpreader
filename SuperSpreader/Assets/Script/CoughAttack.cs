using System.Collections;
using System.Collections.Generic;
using UnityEngine;




  


public class CoughAttack : MonoBehaviour
{

    public bool coughing;  
    public float attack_time;
    public KeyCode lastHitKey;



    // Time between attacks
    public float start_time;

    public Transform infect_pos;
    public float infect_range;
    public LayerMask enemies;
    public Renderer rend;
     public bool going_right;
    public bool going_left;
    public bool going_up;
    public bool going_down;
    public bool aPress;

    public bool facingRight = true;

   

  
  
    // Start is called before the first frame update

        
    Animator anim;
    

    // Start is called before the first frame update
    void Start()

    {
    
          going_down = false;
        going_up = true;
        going_right = false;
        going_left = false;
      
 rend = GetComponent<Renderer>();
        rend.enabled = false;

  
        anim = GetComponent<Animator> ();
        coughing = false;

    
    }



    // Update is called once per frame
    void Update()

    {
          if (Input.GetKeyDown(KeyCode.A))
  {
     lastHitKey = KeyCode.A;

  }
         if (Input.GetKeyDown(KeyCode.D))
  {
     lastHitKey = KeyCode.D;

  }
  
         if(attack_time <= 2.5f)
        {
        coughing = false;
        rend.enabled = false;
        }

     // When W key pressed move up and start walking up animation
        if (Input.GetKey(KeyCode.W))
        {
            if(lastHitKey == KeyCode.A)
            {
                aPress = true;
                transform.localPosition = new Vector2(0, 0.3f);
                transform.rotation = Quaternion.identity;
                transform.eulerAngles = Vector3.forward * -90;
            }
            else{
        aPress = false;

          

            going_down = false;
            going_up = true;
            going_right = false;
            going_left = false;
            transform.localPosition = new Vector2(0, 0.3f);
            transform.rotation = Quaternion.identity;
         transform.eulerAngles = Vector3.forward * 90;
    
       
        }
        }
        

        // When S key pressed move down and start walking down animation
        else if (Input.GetKey(KeyCode.S))
        {
         if(lastHitKey == KeyCode.A)
            {
                aPress = true;
                transform.localPosition = new Vector2(0, -0.3f);
                transform.rotation = Quaternion.identity;
                transform.eulerAngles = Vector3.forward * 90;
            }
            else{
aPress = false;
            going_down = true;
            going_up = false;
            going_right = false;
            going_left = false;

           transform.localPosition = new Vector2(0, -0.3f);
            transform.rotation = Quaternion.identity;
           transform.eulerAngles = Vector3.forward * -90;
           
        }
        }

        // When A key pressed move lef and start walking right animation
        else if (Input.GetKey(KeyCode.A))
        {
       

            going_down = false;
            going_up = false;
            going_right = false;
            going_left = true;
             transform.localPosition = new Vector2(0.24f,0.019f );

                transform.rotation = Quaternion.identity;
                

        }

        // When A key pressed move right and start walking right animation
        else if (Input.GetKey(KeyCode.D))
        {
            
           
            going_down = false;
            going_up = false;
            going_right = true;
            going_left = false;
            transform.localPosition = new Vector2(0.24f,0.019f );

            transform.rotation = Quaternion.identity;
        }
        // if c pressed find all enemies in range and infect them
        if (attack_time <= 0)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                coughing = true;
                        rend.enabled = true;

             
 
        
         
            anim.Play("cough");
                Collider2D[] enemy_to_infect = Physics2D.OverlapCircleAll(infect_pos.position, infect_range, enemies);
                for (int i = 0; i < enemy_to_infect.Length; i++)
                {
                    enemy_to_infect[i].GetComponent<Infection_Risk>().CoughInfectionRisk();
                    
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
