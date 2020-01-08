using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeResupply : MonoBehaviour
{
    public GM GM;
    float timer;
    bool inZone;
    public float RessuplyInterval;
    void Update()
    {
        if(GM.Driver.Driving)
        {
            inZone = false;
        }
        if(inZone)
        {
            Ressuply();
        }
    }

    void Ressuply()
    {
        timer += Time.deltaTime;
        if(timer >= RessuplyInterval && GM.BM.thrower.inventory < GM.BM.thrower.MaxInventory)
        {
            GM.BM.thrower.inventory++;
            timer = 0f;
        }
        else if(GM.BM.thrower.inventory == GM.BM.thrower.MaxInventory)
        { 
            timer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Check 4");
            inZone = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Check 5");
            inZone = false;
        }
    }    
}
    
