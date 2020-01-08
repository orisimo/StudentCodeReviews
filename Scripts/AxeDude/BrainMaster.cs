using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainMaster : MonoBehaviour
{
    public GM GM;
    public GameObject Brain;
    public Inventory inventory;
    public Mover mover;
    public Thrower thrower;
    public GunState shooter;
    public Health health;
    public WeaponSelector WS;
    public Pickup pickup;
    public Rigidbody AxeDudeRB;
    
    void Update()
    {
        if (health.Dead)
        {
            _Dead();
        }
    }

    void _Dead()
    {
        Brain.SetActive(false);
        AxeDudeRB.constraints = RigidbodyConstraints.None;
    }
}
