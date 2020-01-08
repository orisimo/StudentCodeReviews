using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Animator GunAnim;
    public GM GM;
    public GunState gunstate;
    public Camera FPcam;

    public Vector3 GunHipPos, GunAimPos;
    public float CameraHipAngle, CameraAimAngle, timer;

    private void Start()
    {
        CameraHipAngle = FPcam.fieldOfView;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gunstate.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            int EmptySpots = 5 - gunstate.InMag;
            if (gunstate.Ammo > 0f)
            {
                if (EmptySpots > gunstate.Ammo)
                {                    
                    GM.UI.Reload(gunstate.Ammo, gunstate.InMag);
                    gunstate.InMag += gunstate.Ammo;
                    GM.BM.inventory.Ammo = 0;
                }
                else
                {
                    GM.UI.Reload(EmptySpots, gunstate.InMag);
                    GM.BM.inventory.Ammo -= EmptySpots;
                    gunstate.InMag = 5;
                }
            }           
        }
          
               
        if (Input.GetKey(KeyCode.Mouse1))        
        {        
           // GunAnim.SetBool("Aim", true);            
        }        
        else        
        {        
           // GunAnim.SetBool("Aim", false);
           
        }
    }
}


