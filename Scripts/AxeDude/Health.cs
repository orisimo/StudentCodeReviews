using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour
{
    public float health;
    public bool Hit, Dead;    

    private void Update()
    {       
        if(Hit)
        {
             health -= Random.Range(2f, 8f);
             Hit = false;
            if (health <= 0f)
            {
                health = 0f;
                Dead = true;
            }
        }        
    }        
}
