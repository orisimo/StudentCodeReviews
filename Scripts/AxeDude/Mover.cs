using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GM GM;
    public GameObject Camera, AxeDude;
    public Rigidbody RB;
    public int Speed, topSpeed, jumoforce;
    public bool OnGround;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        RB = GetComponentInParent<Rigidbody>();        
    }

    private void Update()
    {        
        if (!GM.IGM.isPaused)
        {
            AxeDude.transform.Rotate(0f, Input.GetAxis("Mouse X"), 0f);
            Camera.transform.Rotate(-Input.GetAxis("Mouse Y"), 0f, 0f);
            if (270 > Camera.transform.localEulerAngles.x && Camera.transform.localEulerAngles.x > 70f)
            {
                Camera.transform.localEulerAngles = new Vector3(70f, Camera.transform.localEulerAngles.y, Camera.transform.localEulerAngles.z);
            }
            if (270 < Camera.transform.localEulerAngles.x && Camera.transform.localEulerAngles.x < 285f)
            {
                Camera.transform.localEulerAngles = new Vector3(285f, Camera.transform.localEulerAngles.y, Camera.transform.localEulerAngles.z);
            }
            if (Input.GetKeyDown(KeyCode.Space) && OnGround)
            {                
                _Jump();
            }
        }
    }
    private void FixedUpdate()
    {
        _Movment();
    }

    void _Movment()
    {
        if(RB.velocity.magnitude <= topSpeed)
        {
            AxeDude.transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") / (Speed * 4f)));
            AxeDude.transform.Translate(Vector3.right * (Input.GetAxis("Horizontal") / (Speed * 4f)));
        }        
    }

    void _Jump()
    {        
        RB.AddForce((transform.up * jumoforce) + (transform.forward * RB.velocity.magnitude), ForceMode.Impulse);
        OnGround = false;        
    }
    private void OnCollisionStay(Collision collision)
    {
        OnGround = true;
    }        
}
