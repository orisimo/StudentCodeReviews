using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Thrower : MonoBehaviour
{
    public GameObject AxeThrown, AxeThrownRef, AxeHeld;
    public GM GM;    
    public float Power;
    public int MaxInventory, inventory;
    bool inFlight;    
    public int Index = 0;
    float timer = 0f;

    private void Start()
    {        
        GM = GetComponentInParent<GM>();
    }
    void Update()
    {
        if (!GM.IGM.isPaused)
        {
            _PowerSet();
            _Throw();
            _ThrowDelay();
            if (inventory == 0)
            {
                AxeHeld.SetActive(false);
            }
            else
            {
                AxeHeld.SetActive(true);
            }            
        }
    }

    void _PowerSet()
    {

        if (Input.GetKey(KeyCode.Mouse0) && inventory > 0)
        {
            if (Power < 0.5f)
            {
                Power += Time.deltaTime;
            }
            else if (Power >= 0.5f)
            {
                Power = 0.5f;
            }
        }
        else
        {
            if (Power > 0f)
            {
                Power -= Time.deltaTime * 10;
            }
            else
            {
                Power = 0f;
            }
        }
        GM.UI._SetAxeIndicator(Power, 0.5f);
        _AxePrep();
    }

    void _AxePrep()
    {
        AxeHeld.transform.localRotation = Quaternion.Euler(Mathf.Lerp(0, -45, Power / 0.5f), 0f, 0f);
    }

    void _Throw()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && inventory > 0)
        {                        
            _Spawn();                    
            --inventory;
            inFlight = true;
            AxeHeld.SetActive(false);            
        }
    }

    void _ThrowDelay()
    {
        if (inFlight)
        {
            AxeHeld.SetActive(false);
            timer += Time.deltaTime;
            if (timer >= 0.5f)
            {
                inFlight = false;
                AxeHeld.SetActive(true);
                timer = 0f;
            }
        }
    }
    
    void _Spawn()
    {        
        GameObject Axe1 = Instantiate(AxeThrown, AxeThrownRef.transform);
        Throw throw1 = Axe1.GetComponent<Throw>();
        throw1.GM = GM;
        throw1.thrower = this;        
        Axe1.SetActive(true);                       
    }  
    
}
    

