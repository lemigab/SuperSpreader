using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDirection : MonoBehaviour
{
    public static bool going_up;
    public static bool going_down;
    public static bool going_right;
    public static bool going_left;
    // Start is called before the first frame update
    void Start()
    {
        going_up = false;
        going_down = false;
        going_right = false;
        going_left = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (CoughAttack.infect_pos )
    }
}
