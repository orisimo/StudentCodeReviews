using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunState : MonoBehaviour
{    
    public float MuzzleVelocity;
    public bool Firing, OpeningBolt;
    public int Ammo, InMag;
    public PlayerShooter PS;
    public GameObject Ref, Projectile;
    public Gunshot Gs;


    public void Shoot()
    {
        AnimatorStateInfo info = PS.GunAnim.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Idel") || info.IsName("Aim"))
        {
            if (InMag > 0)
            {
                Debug.Log("Check");
                Firing = true;
                PS.GunAnim.SetBool("Firing", true);
            }
        }
    }

    public void SpawnShot()
    {
        PS.GM.UI.Round[5 - InMag].SetActive(false);
        Gs.shooting = true;        
        --InMag;
        GameObject Shot = Instantiate(Projectile, Ref.transform.position, Ref.transform.rotation);
        Rigidbody RBshot = Shot.GetComponent<Rigidbody>();
        RBshot.AddForce(Shot.transform.forward * MuzzleVelocity, ForceMode.VelocityChange);
    }

    public void BackToIdel()
    {
        Firing = false;
        PS.GunAnim.SetBool("Firing", false);       
    }
}
