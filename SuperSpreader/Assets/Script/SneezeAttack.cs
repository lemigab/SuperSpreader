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

    public bool sneeze_up;

    public bool sneeze_down;

    public bool sneeze_right;

    public bool sneeze_left;

    public CapsuleDirection2D cap_dir;



    // Start is called before the first frame update
    void Start()
    {
        move = false;
        rend = GetComponent<Renderer>();
        rend.sortingLayerName = "Hide";
        sneeze_up = true;
        sneeze_down = false;
        sneeze_right = false;
        sneeze_left = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (attack_time <= 0)
        {

            rend.sortingLayerName = "Hide";
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
        Contact();

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
                if (sneeze_down == true)
                {
                    transform.Rotate(0, 0, 180);
                    sneeze_down = false;
                }
                if (sneeze_right == true)
                {
                    transform.Rotate(0, 0, 90);
                    sneeze_right = false;
                }
                if (sneeze_left == true)
                {
                    transform.Rotate(0, 0, -90);
                    sneeze_left = false;
                }
                sneeze_up = true;
                transform.Translate(speed * Time.deltaTime * Vector3.up);



            }

            if (dir == "down")
            {
                if (sneeze_up == true)
                {
                    transform.Rotate(0, 0, 180);
                    sneeze_up = false;
                }
                if (sneeze_right == true)
                {
                    transform.Rotate(0, 0, -90);
                    sneeze_right = false;
                }
                if (sneeze_left == true)
                {
                    transform.Rotate(0, 0, -270);
                    sneeze_left = false;
                }
                sneeze_down = true;
                transform.Translate(speed * Time.deltaTime * Vector3.up);
            }

            if (dir == "right")
            {
                if (sneeze_down == true)
                {
                    transform.Rotate(0, 0, 90);
                    sneeze_down = false;
                }
                if (sneeze_up == true)
                {
                    transform.Rotate(0, 0, -90);
                    sneeze_up = false;
                }
                if (sneeze_left == true)
                {
                    transform.Rotate(0, 0, 180);
                    sneeze_left = false;
                }
                sneeze_right = true;
                transform.Translate(speed * Time.deltaTime * Vector3.up);

            }

            if (dir == "left")
            {
                if (sneeze_down == true)
                {
                    transform.Rotate(0, 0, 270);
                    sneeze_down = false;
                }
                if (sneeze_right == true)
                {
                    transform.Rotate(0, 0, 180);
                    sneeze_right = false;
                }
                if (sneeze_up == true)
                {
                    transform.Rotate(0, 0, 90);
                    sneeze_up = false;
                }
                sneeze_left = true;
                transform.Translate(speed * Time.deltaTime * Vector3.up);
            }
        }
    }

    // When hits a enemy
    public void Contact()
    {
        if (rend.sortingLayerName == "Floor")
        {

            Collider2D[] lick_infect = Physics2D.OverlapCapsuleAll(transform.position, sneeze_size, cap_dir, enemies);
            for (int i = 0; i < lick_infect.Length; i++)
            {
                if (lick_infect[i].gameObject.layer == 12)
                {
                    lick_infect[i].GetComponent<Infection_Risk>().SneezeInfectionRisk();
                    Debug.Log("gone");
                    rend.sortingLayerName = "Hide";
                    move = false;
                }
                if (lick_infect[i].gameObject.layer == 15)
                {
                    rend.sortingLayerName = "Hide";
                    move = false;
                }
            }

        }

    }
}
