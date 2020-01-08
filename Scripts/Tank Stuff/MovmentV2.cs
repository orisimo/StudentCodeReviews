using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovmentV2 : MonoBehaviour
{
    public float gear = 0f;
    public GM GM;
    public Rigidbody RB;   
    Vector3 Deccel, ratio, Turn;
    float azim;

    private void Update()
    {
        if (!GM.IGM.isPaused)
        {
            _GearCheck();
        }
    }
    void FixedUpdate()
    {        
        if (Input.GetKey(KeyCode.W))
        {
            if (gear > 0f)
            {
                RB.AddForce(ratio/4, ForceMode.VelocityChange);
            }
            if (gear < 0f)
            {
                RB.AddForce(-ratio/4, ForceMode.VelocityChange);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (RB.velocity.magnitude != 0f)
            {
                RB.AddForce(-Deccel/4, ForceMode.Acceleration);
            }
        }
        if (Input.GetButton("Horizontal"))
        {
            transform.Rotate(Turn/4);
        }
    }

    

    
    void _GearCheck()
    {
        if (Input.GetKeyDown(KeyCode.E) && gear < 5f)
        {
            ++gear;
        }
        if (Input.GetKeyDown(KeyCode.Q) && gear > -2f)
        {
            --gear;
        }
        ratio = transform.forward / Mathf.Lerp(3.8f, 2.5f, Mathf.Abs(gear) / 5);
        Deccel = RB.velocity / 4f;
        Turn = new Vector3(0, Input.GetAxis("Horizontal") * gear / 5, 0);
    }
}
