using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    Rigidbody RB;
    public float Timer, LifeTime;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= LifeTime)
        {
            Despawn();
        }
    }

    void Despawn()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "EB")
        {
            if (collision.gameObject.tag != "Enemy")
            {
                Despawn();
            }
        }
        if (gameObject.tag == "Shot")
        {

            if (collision.gameObject.tag != "Player")
            {
                Despawn();
            }
            else
            {
                Pickup PU = collision.gameObject.GetComponent<Pickup>();
            }
        }
        //if(collision.)
    }
}
