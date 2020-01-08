using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovment : MonoBehaviour
{
    public GM GM;
    public GameObject Turret, Gun, Camera;
    public float RotationRate;
    float azim, pos, Elev;

    void Update()
    {
        if (!GM.IGM.isPaused)
        {
            azim -= Input.GetAxis("Mouse X");
            if(azim <= -360f)
            {
                azim += 360f;
            }
            if(azim >= 360f)
            {
                azim -= 360f;
            }            
            _Rotate();
            _Elevation();
            Camera.transform.localRotation = Quaternion.Euler(Elev, -azim, 0f);
        }
    }

    void _Rotate()
    { 
        if (Mathf.Abs(pos-azim) > 1f)
        {
            if (azim < pos)
            {
                Turret.transform.Rotate(0f, (RotationRate * Time.deltaTime),0f);
                pos -=  RotationRate * Time.deltaTime;
            }
            else if(azim > pos)
            {
                Turret.transform.Rotate(0f, -(RotationRate * Time.deltaTime), 0f);
                pos += RotationRate * Time.deltaTime;
            }            
        }
    }
    void _Elevation()
    {
        Elev += Input.GetAxis("Mouse Y");
        Elev = Mathf.Clamp(Elev, -20f, 10f);
        Gun.transform.localRotation = Quaternion.Euler(Elev, 0f, 0f) ;
        
    }
}
