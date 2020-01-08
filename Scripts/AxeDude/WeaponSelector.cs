using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public string selected ="Axe";
    public BrainMaster BM;
    Thrower thrower;
    PlayerShooter shooter;
    public GameObject Axe, Gun;

    private void Start()
    {
        selected = "Axe";
        thrower = GetComponent<Thrower>();
        shooter = GetComponent<PlayerShooter>();
    }


    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _Axe();
            
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _Gun1();
            
        }
    }
    

    void _Axe()
    {
        selected = "Axe";
        BM.GM.UI.SelectWeapon(selected, 0);
        thrower.enabled = true;
        shooter.enabled = false; //
        Axe.SetActive(true);
        Gun.SetActive(false);
    }

    void _Gun1()
    {       
        selected = "Gun1";
        BM.GM.UI.SelectWeapon(selected, 1);
        thrower.enabled = false;
        shooter.enabled = true;
        Axe.SetActive(false);
        Gun.SetActive(true);
    }
}
