using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : MonoBehaviour
{
    public Enemy E;
    public GM GM;
    float timer = 0f;
    public float DespawnTime;

    private void Start()
    {
        GM = E.GM;
    }
    void Update()
    {
        if (!GM.IGM.isPaused)
        {
            timer += Time.deltaTime;
            if (timer >= DespawnTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
