using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour
{
    public Thrower thrower;
    public GM GM;
    public int ThrowMultiplie, RotationMultiplier, Index;
    public float DeathTimer, DeathTime;
    public bool hit = false;
    public bool canPickup = false;
    public bool isPickedup = false;

    private void OnEnable()
    {
        transform.parent = GM.GameWorld.transform;
        GM.AxeCount++;
        Rigidbody RB = GetComponent<Rigidbody>();
        RB.AddForce(transform.forward * thrower.Power * ThrowMultiplie, ForceMode.Impulse);
        RB.AddTorque(transform.right * thrower.Power * ThrowMultiplie * RotationMultiplier, ForceMode.Force);        
    }
    

    private void FixedUpdate()
    {        
        if (DeathTimer > 0.5f)
        {
            canPickup = true;
        }
        DeathTimer += Time.deltaTime;
        if (isPickedup || DeathTimer >= DeathTime)
        {            
            _Despawn();
        }                    
    }


    
    

    public void _Despawn()
    {                   
        GM.AxeCount--;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Enemy" )
        {            
            hit = true;
        }                
    }
}
