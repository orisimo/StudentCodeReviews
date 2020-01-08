using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public Text text;
    public Text summery;
    public Image BG;
    public GM GM;
    public float Timer, PlayTime;
    bool dead;

    private void Start()
    {
        summery.text = "After Shooting " + GM.GunKillCount +" Germnas dead, and Axing a further " + GM.AxeKillcount +", you finally succumb to acute lead posioning";
    }

    void Update()
    {

        if(Timer < PlayTime)
        {
            float aval = (Timer / PlayTime);
            Vector4 color = new Vector4(1f,1f,1f, aval);
            text.color = color;
            summery.color = color;
            BG.color = new Vector4(0f, 0f, 0f, aval);
            Timer += Time.deltaTime;
        }
        else
        {
            text.color = new Vector4(1f, 1f, 1f, 1f);
            BG.color = new Vector4(0f, 0f, 0f, 1f);
        }        
        if(Timer >= 2 && Input.anyKeyDown)
        {            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("Start");
        }        
    }
}
