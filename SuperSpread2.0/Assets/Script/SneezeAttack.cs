using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneezeAttack : MonoBehaviour
{
    public float attack_time;
    public float start_attack_time;

    public float speed;

    public Transform infection_pos;

    public LayerMask enemies;

    private Renderer rend;

    private bool move;

    public Movement mov;

    private string dir;

    public Vector2 sneeze_size;

    public CapsuleDirection2D cap_dir;

    // Start is called before the first frame update
    void Start()
    {
        move = false;
        rend = GetComponent<Renderer>();
        rend.sortingLayerName = "Behind";
    }

    // Update is called once per frame
    void Update()
    {

        if (attack_time <= 0 )
        {
            
            rend.sortingLayerName = "Behind";
            if (Input.GetKeyDown(KeyCode.B))
            {
                Direction();
                transform.position = infection_pos.position;
                rend.sortingLayerName = "Floor";
                move = true;
                attack_time = start_attack_time;
            } 

        }
        attack_time -= Time.deltaTime;
        Move();

    }

    // Function to determine direction of sneeze attack depending on which way the player is facing
    public void Direction()
    {
        if (mov.going_up == true)
        {
            dir = "up";
        }

        if (mov.going_down == true)
        {
            dir = "down";
        }

        if (mov.going_right == true)
        {
            dir = "right";
        }

        if (mov.going_left == true)
        {
            dir = "left";
        }
    }

    // Moves the sneeze depending on direction of sneeze
    public void Move()
    {
        if (move == true)
        {
            if (dir == "up")
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

            if (dir == "down")
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }

            if (dir == "right")
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            if (dir == "left")
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
    }

    // When hits a enemy
    public void Contact()
    {
        if (rend.sortingLayerName == "Floor")
        {
            move = false;
            //Collider2D[] lick_infect = Physics2D.OverlapCapsuleAll(transform.position, sneeze_size, cap_dir, enemies);
            //for (int i = 0; i < lick_infect.Length; i++)
            //{
            //    lick_infect[i].GetComponent<infection_risk>().SneezeInfectionRisk();
            //}
            rend.sortingLayerName = "Behind";
            transform.position = infection_pos.position;
            Debug.Log("hit");
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Contact();
    }
}
