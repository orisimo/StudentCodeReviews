using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    int SpwanCount;
    public bool Spawn;
    public MovmentV2 Mover;
    public Driver Driver;
    public IngameMenu IGM;
    public UIcontrol UI;
    public GameObject EnemyModel, AxeDude, Tank, Brain, GO, GameWorld;
    public BrainMaster BM;
    public GameObject[] SpawnPoints;
    public GameObject[] Targets;
    public int MaxEnemy, MaxAxe;
    public int EnemyCount, AxeCount, AxeKillcount, GunKillCount;
    public float Timer, SpawnInterval;

    void Update()
    {
        if (Spawn)
        {
            if (EnemyCount < MaxEnemy)
            {
                Timer += Time.deltaTime;
                if (Timer >= SpawnInterval)
                {
                    _Spawn();
                    Timer = 0f;
                }
            }
            else
            {
                Timer = 0f;
            }
        }
        if (BM.health.Dead)
        {
            _GameOver();
        }
    }

    void _Spawn()
    {
        EnemyCount++;
        SpwanCount++;
        int pos = Random.Range(0, 6);
        GameObject enemy = Instantiate(EnemyModel, SpawnPoints[pos].transform.position, SpawnPoints[pos].transform.rotation);
        enemy.name = "Hans #" + SpwanCount;
        Enemy E = enemy.GetComponent<Enemy>();
        E.GM = this;
    }

    void _GameOver()
    {
        GO.SetActive(true);
    }
}
