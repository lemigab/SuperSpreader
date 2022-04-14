using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveai : MonoBehaviour
{
    public bool going_right;
    public bool going_left;
    public bool going_up;
    public bool going_down;

    public float speed = 3.0f;

    public bool facingRight = true; //Depends on if your animation is by default facing right or left

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        going_down = false;
        going_up = true;
        going_right = false;
        going_left = false;
        anim.SetBool("idle_up", true);
    }

    // Update is called once per frame
    void Update()
    {
        // When W key pressed move up and start walking up animation
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            anim.SetBool("walking_up", true);
            anim.SetBool("walking_down", false);
            anim.SetBool("walking_right", false);
            anim.SetBool("idle_right", false);
            anim.SetBool("idle_up", false);
            anim.SetBool("idle_down", false);

            going_down = false;
            going_up = true;
            going_right = false;
            going_left = false;

        }

        // When S key pressed move down and start walking down animation
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            anim.SetBool("walking_down", true);
            anim.SetBool("walking_up", false);
            anim.SetBool("walking_right", false);
            anim.SetBool("idle_right", false);
            anim.SetBool("idle_up", false);
            anim.SetBool("idle_down", false);

            going_down = true;
            going_up = false;
            going_right = false;
            going_left = false;

        }

        // When A key pressed move lef and start walking right animation
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            anim.SetBool("walking_right", true);
            anim.SetBool("walking_up", false);
            anim.SetBool("walking_down", false);
            anim.SetBool("idle_right", false);
            anim.SetBool("idle_up", false);
            anim.SetBool("idle_down", false);

            going_down = false;
            going_up = false;
            going_right = false;
            going_left = true;

        }

        // When A key pressed move right and start walking right animation
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            anim.SetBool("walking_right", true);
            anim.SetBool("walking_up", false);
            anim.SetBool("walking_down", false);
            anim.SetBool("idle_right", false);
            anim.SetBool("idle_up", false);
            anim.SetBool("idle_down", false);

            going_down = false;
            going_up = false;
            going_right = true;
            going_left = false;

        }


        // Flips the character on the X Axis depending on which way he is facing
        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        // Changes to idle position when keys are not pressed anymore
        if (!Input.anyKey)
        {

            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("idle_up", true);
                anim.SetBool("walking_up", false);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetBool("idle_down", true);
                anim.SetBool("walking_down", false);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetBool("idle_right", true);
                anim.SetBool("walking_right", false);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetBool("idle_right", true);
                anim.SetBool("walking_right", false);
            }
        }

    }

    // Flip function to flip character on x or y axis
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

