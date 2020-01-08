using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camswitch : MonoBehaviour
{
    public GM GM;
    [SerializeField] public GameObject[] Cam;
    int sel = 1;
    
    void Update()
    {
        if (!GM.IGM.isPaused)
        {
            Cam[sel].SetActive(true);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Cam[sel].SetActive(false);
                ++sel;
                if (sel < Cam.Length)
                {
                    _UISet();                    
                }
                else
                {
                    sel = 0;
                    _UISet();
                }
            }
            if(Input.GetKeyDown(KeyCode.Y))
            {

            }
        }
    }

    void _UISet()
    {
        if (Cam[sel].gameObject.name == "Sight")
        {
            GM.UI._CloseUI();
            GM.UI.TankUI.SetActive(true);
            GM.UI.Sight.SetActive(true);
        }
        if (Cam[sel].gameObject.name == "External")
        {
            GM.UI._CloseUI();
            GM.UI.TankUI.SetActive(true);
            GM.UI.External.SetActive(true);
        }
    }

    
}
