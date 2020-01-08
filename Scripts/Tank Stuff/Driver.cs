using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public GM GM;
    public GameObject AxeDude;
    public Camswitch CS;
    public MovmentV2 Mover;
    public TurretMovment TR;
    public WC WC;
    public Collider EnterBox;
    public bool Driving, Entering;


    private void Update()
    {
        if (!GM.IGM.isPaused)
        {
            
            if (Driving)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Driving = false;
                    AxeDude.transform.SetParent(null);
                    NotDriving();
                }
            }
            else if (Entering && !Driving)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Driving = true;
                    AxeDude.transform.SetParent(this.transform);
                    IsDriving();
                }
            }
            if (!Driving)
            {
                WC.MGFlash.SetActive(false);
                WC.enabled = false;
            }
        }
    }
    void IsDriving()
    {
        AxeDude.SetActive(false);
        GM.UI._Driving();
        CS.enabled = TR.enabled = Mover.enabled = WC.enabled = true;
    }

    void NotDriving()
    {
        for(int i =0; i < CS.Cam.Length; ++i)
        {
            CS.Cam[i].SetActive(false);
        }
        AxeDude.SetActive(true);
        GM.UI._OnFoot();
        CS.enabled = TR.enabled = Mover.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Entering = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Entering = false;
        }
    }
}
