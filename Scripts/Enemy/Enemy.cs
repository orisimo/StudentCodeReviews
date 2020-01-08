using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float Distance,Timer;    
    public bool Kill, Shooting;
    public int min, max, Target, DescisonInterval, Chance;
    public float Speed, maxSpeed, StandoffDis, MinRange;    
    public Renderer Mat;
    public Material Dead;
    public GameObject Gun, GunProp, Hans, Helmet, HelmetProp;
    public GM GM;    
    public EnemyDespawn Despawn;
    public Rigidbody RB;
    public Shooter shooter;
    public Gunshot Gs;
    void Start()
    {        
        Despawn = GetComponent<EnemyDespawn>();        
        RB = GetComponent<Rigidbody>();
        GameObject Game = GameObject.FindGameObjectWithTag("Game");
        shooter = GetComponent<Shooter>();
        GM = Game.GetComponent<GM>();
    }
    
    void Update()
    {       
        if (!GM.IGM.isPaused)
        {            
            if(Timer >= DescisonInterval && !Shooting)
            {
                StandoffDis = Random.Range(min * 10f, (max + 1) * 10f) / 10f;
                int Ref = Target;
                Target = Random.Range(0, GM.Targets.Length);
                Timer = 0f;
                if(Target == Ref)
                {
                    int Luck = Random.Range(1, 101);
                    if(Luck <= Chance)
                    {
                        Shooting = true;
                    }                    
                }
            }
            if (Shooting)
            {
                RB.velocity = new Vector3(0f,0f,0f);
                LookAtTraget();
                Timer += Time.deltaTime;
                if(Timer >= 3f)
                {
                    shooter.Shoot();
                    Shooting = false;
                    Timer = 0f;
                }                
            }
            else
            {
                Timer += Time.deltaTime;
                Distance = _DistanceCalc(GM.Targets[Target].transform);
                LookAtTraget();
            }

            Distance = _DistanceCalc(GM.AxeDude.transform);
            if (Distance <= MinRange && Timer != 0f)
            {
                Target = 0;
                Shooting = true;
            }
        }
    }
    private void FixedUpdate()
    {       
       if (Distance >= StandoffDis && RB.velocity.magnitude <= maxSpeed &&!Shooting)    
       {        
           RB.AddForce(transform.forward * Speed, ForceMode.VelocityChange);            
       }        
       else if (Distance < StandoffDis && RB.velocity.magnitude <= maxSpeed && !Shooting)        
       {        
           RB.AddForce(-transform.forward * Speed, ForceMode.VelocityChange);            
       }
       
    }

    void LookAtTraget()
    {
        transform.LookAt(GM.Targets[Target].transform);
        transform.rotation = Quaternion.Euler(0f, transform.localEulerAngles.y, 0f);
        shooter.Ref.transform.LookAt(GM.Targets[Target].transform);
    }

    public float _DistanceCalc(Transform Target)
    {
        float Distance;
        Vector3 A, B;
        A = transform.position;
        B = Target.transform.position;
        float DisX = Mathf.Abs(Mathf.Abs(A.x) - Mathf.Abs(B.x));
        float DisY = Mathf.Abs(Mathf.Abs(A.y) - Mathf.Abs(B.y));
        float DisZ = Mathf.Abs(Mathf.Abs(A.z) - Mathf.Abs(B.z));
        Distance = Mathf.Sqrt(Mathf.Pow(DisX, 2) + Mathf.Pow(DisY, 2) + Mathf.Pow(DisZ, 2));        
        return Distance;
    }

    public void _Kill()
    {
        Mat.material = Dead;       
        tag = "Dead";        
        RB.constraints = RigidbodyConstraints.None;
        GM.EnemyCount--;        
        Despawn.enabled = true;
        enabled = false;              
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Shot")
        {
            Rigidbody RBshot = collision.gameObject.GetComponent<Rigidbody>();
            if (RBshot.velocity.magnitude >= 60 && !Kill)
            {
                Vector3 p = Gun.transform.position;
                Quaternion r = Gun.transform.rotation;
                Destroy(Gun);
                GameObject GunP = Instantiate(GunProp, p, r);
                GunP.tag = "PickableGun";
                EnemyDespawn GunD = GunP.GetComponent<EnemyDespawn>();
                GunD.E = this;
                Rigidbody RB = GunP.GetComponent<Rigidbody>();
                RB.AddForce(-GunP.transform.right * 10f, ForceMode.Impulse);
                Kill = true;
                GM.GunKillCount++;
                _Kill();
            }
        }
        if(collision.gameObject.tag == "ThrownAxe")
        {            
            Throw Throw = collision.gameObject.GetComponent<Throw>();
            if(Throw.hit == false && !Kill)
            {                
                Vector3 p = Gun.transform.position;
                Quaternion r = Gun.transform.rotation;

                Destroy(Helmet);
                Destroy(Gun);
                
                GameObject HelmP = Instantiate(HelmetProp, (transform.position) + new Vector3(0f, 2f, 0f), transform.rotation);
                GameObject GunP = Instantiate(GunProp, p, r);
                
                EnemyDespawn GunD = GunP.GetComponent<EnemyDespawn>();
                EnemyDespawn HelmD = HelmP.GetComponent<EnemyDespawn>();

                GunD.E = this;
                HelmD.E = this;

                Rigidbody RB = GunP.GetComponent<Rigidbody>();
                RB.AddForce(-GunP.transform.right*10f, ForceMode.Impulse);
                Kill = true;
                collision.gameObject.transform.SetParent(this.transform);
                Collider[] Collisions = collision.gameObject.gameObject.GetComponents<Collider>();
                RB = collision.gameObject.GetComponent<Rigidbody>();                                              
                for(int i = 0; i < Collisions.Length; i++)
                {
                    Debug.Log(i);
                    Destroy(Collisions[i]);
                }
                Destroy(RB);
                GM.AxeKillcount++;
                _Kill();
            }            
        }
    }
}
