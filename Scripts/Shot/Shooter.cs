using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public int MaxAmmo, Ammo, InMag,MuzzleVelocity;
    public float Timer, CycleTime;
    public bool Cycling;
    public GM GM;
    public GameObject Ref, Projectile;
    public Gunshot Gs;

    private void Start()
    {
        
    }
    void Update()
    {
        if(Cycling)
        {
            Cycle();
        }        
    }
    
    public void Shoot()
    {        
        Gs.shooting = true;
        GameObject Shot = Instantiate(Projectile, Ref.transform.position, Ref.transform.rotation);
        Rigidbody RBshot = Shot.GetComponent<Rigidbody>();
        RBshot.AddForce(Shot.transform.forward * MuzzleVelocity, ForceMode.VelocityChange);
    }
    void Cycle()
    {        
        Timer += Time.deltaTime;
        if(Timer > CycleTime)
        {
            Cycling = false;
            Timer = 0f;
        }
    }
}
