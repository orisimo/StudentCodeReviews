using UnityEngine;

public class Tracks : MonoBehaviour
{
    public MovmentV2 Mover;
    public Material TrackL;
    public Material TrackR;
    public Rigidbody RB;
    float Offset_L = 0f;
    float Offset_R = 0f;
    void Update()
    {
        Offset_L += RB.velocity.magnitude * Time.deltaTime / 10;
        Offset_R += RB.velocity.magnitude * Time.deltaTime / 10;
        if(Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W) == false)
            {
                Offset_R += Time.deltaTime / 10f;
            }            
            Offset_L -= RB.velocity.magnitude * Time.deltaTime / 20f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W) == false)
            {
                Offset_L += Time.deltaTime / 10f;
            }
            Offset_R -= RB.velocity.magnitude * Time.deltaTime / 20f;
        }
        if (Mover.gear > 0)
        {
            TrackL.mainTextureOffset = new Vector2(0, Offset_L);
            TrackR.mainTextureOffset = new Vector2(0, Offset_R);
        }
        if (Mover.gear < 0)
        {
            TrackL.mainTextureOffset = new Vector2(0, -Offset_L);
            TrackR.mainTextureOffset = new Vector2(0, -Offset_R);
        }
    }
}
