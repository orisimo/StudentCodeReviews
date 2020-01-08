using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : MonoBehaviour
{
    public AudioClip gunshot;
    public AudioSource AS;
    public bool shooting;
    public float timer, StopTime;
    void Start()
    {
        AS.clip = gunshot;        
    }
    void Update()
    {       
        if(shooting)
        {
            timer += Time.deltaTime;
            AS.Play();
            shooting = false;
        }        
    }
}
