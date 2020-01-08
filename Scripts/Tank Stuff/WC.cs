using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WC : MonoBehaviour
{
    public int MGAmmo, CannonAmmo;
    public float MGCycleTime, MGMuzzleVelocity;
    float TimerMG, TimerCannon;
    public GameObject MG, MGProjectile,MGFlash, Cannon  ;
    bool MGcanshoot;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _ShootMG();
        }
        if (MGcanshoot)
        {
                        
        }
        if (TimerCannon != 0)
        {
            TimerCannon += Time.deltaTime;
        }

    }
    void _ShootMG()
    {
        if (TimerMG == 0f)
        {
            MGFlash.SetActive(true);
        }
        else if (TimerMG >= 0.15)
        {
            MGFlash.SetActive(false);
        }
        TimerMG += Time.deltaTime;
        if (MGcanshoot)
        {
            GameObject MGShot = Instantiate(MGProjectile, MG.transform.position, MG.transform.rotation);
            Rigidbody ShotRB = MGShot.GetComponent<Rigidbody>();
            ShotRB.AddForce(MGShot.transform.forward * MGMuzzleVelocity, ForceMode.VelocityChange);
            MGcanshoot = false;
        }
        if(TimerMG >= MGCycleTime)
        {
            MGcanshoot = true;
            TimerMG = 0f;
        }        
    }
}
