using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontrol : MonoBehaviour
{
    public GM GM;
    public Text Gun1, Axe_S, KillCount;
    public Image HealthBar;
    public GameObject TankUI, OnFootUI, Sight, External, Gun, Axe;
    public GameObject[] Piper;
    public RectTransform AxePiperIndicator;
    public GameObject[] Weapon;
    public GameObject[] Round;

    private void Start()
    {
        int i = 0;
        if(GM.BM.WS.selected == "Axe")
        {
            i = 0;
        }
        if (GM.BM.WS.selected == "Gun1")
        {
            i = 1;
        }       
        SelectWeapon(GM.BM.WS.selected, i);
        Reload(5,0);
    }
    void Update()
    {   
        if (GM.BM.health.Dead)
        {
            _CloseUI();
        }
        _HealthUpdate();
        _InventoryUpdate();
        _KillUpdate();
    }

    public void _SetAxeIndicator(float Power, float MaxPower)
    {

        AxePiperIndicator.localPosition = new Vector2(0f, Mathf.Lerp(-50f, 50f, (Power / MaxPower)));
    }
    public void _CloseUI()
    {
        External.SetActive(false);
        Sight.SetActive(false);
        OnFootUI.SetActive(false);
        TankUI.SetActive(false);
    }
    public void _InventoryUpdate()
    {
        if (GM.BM.WS.selected == "Axe")
        {
            Axe_S.text = (" X " + GM.BM.thrower.inventory);
        }
        if (GM.BM.WS.selected == "Gun1")
        {
            Gun1.text = ("/ " + GM.BM.shooter.Ammo);
        }
    }

    public void SelectWeapon(string selection, int index)
    {
        for (int i = 0; i < Weapon.Length; ++i)
        {
            Weapon[i].SetActive(false);
            
        }
        for(int i = 0; i < Piper.Length; ++i)
        {
            Piper[i].SetActive(false);
        }
        Piper[index].SetActive(true);
        Weapon[index].SetActive(true);  
    }

    public void _HealthUpdate()
    {
        HealthBar.rectTransform.localScale = new Vector3(1f, (GM.BM.health.health / 100f), 1f);
    }

    public void _KillUpdate()
    {
        //KillCount.text = ("Enemies Axed: " + GM.Killcount);
    }

    public void _OnFoot()
    {
        OnFootUI.SetActive(true);
        TankUI.SetActive(false);
    }
    public void _Driving()
    {
        TankUI.SetActive(true);
        OnFootUI.SetActive(false);
    }
     public void _AddAmmo(int Amount)
    {
        Debug.Log("Added " + Amount + " Rounds");
    }
    public void Reload(int ToLoad, int InMag)
    {
        Debug.Log(ToLoad + " <To Load\n" + InMag + "<In Mag");
        int pos = 4 - InMag;
        for (int i = ToLoad; i > 0;)
        {
            --i;
            Round[pos].SetActive(true);
            pos--;
        }
    }
}
