using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Thrower thrower;    
        
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ThrownAxe")
        {            
            Throw Axe = collision.gameObject.GetComponent<Throw>();
            if(Axe.canPickup == true && Axe.isPickedup == false && thrower.inventory < thrower.MaxInventory)
            {
                Axe.isPickedup = true;                              
                Axe._Despawn();                
                thrower.inventory++;
            }                        
        }
        if (collision.gameObject.tag == "EB")
        {
            thrower.GM.BM.health.Hit = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            thrower.GM.BM.mover.OnGround = true;
        }
        if(collision.gameObject.tag == "PickableGun")
        {
            int Amount = Random.Range(2, 10);
            thrower.GM.UI._AddAmmo(Amount);
            thrower.GM.BM.inventory.Ammo += Amount;
            Destroy(collision.gameObject);
        }
    }
}
