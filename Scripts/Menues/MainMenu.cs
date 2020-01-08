using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject MM, Instructions;

    private void Update()
    {
        if(Instructions.activeSelf && Input.anyKeyDown)
        {
            Instructions.SetActive(false);
            MM.SetActive(true); 
        }
    }
    public void _StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void _Exit()
    {
        Application.Quit();
    }
}
