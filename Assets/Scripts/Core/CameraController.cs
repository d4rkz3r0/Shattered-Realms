///***********************************************************************
//Class: CameraController.cs
/*Notes:
 */
///***********************************************************************
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
    //Version 1.0
    public float XOffset;
    public float YOffset;

    //Version 2.0
    public bool boundsLock = true;
    public bool followPlayer = true;
    public float lagX;
    public float lagY;
    private float positionX;
    private float positionY;
    private Vector2 cameraVelocity;
    public Vector3 minBounds;
    public Vector3 maxBounds;

    //public bool mangekyouSharingan;
    //private float mangekyouTimer;

    private Camera theCamera;
    private Color color1 = Color.black;
    private Color color2 = Color.red;
    private float timeSpeed = 1.0f;
   
    


    ////Private References
    private MasterController player;

	void Start () 
    {
        theCamera = GetComponent<Camera>();

        //mangekyouSharingan = false;
        //mangekyouTimer = 3.0f;
        //Auto Hook
        player = FindObjectOfType<MasterController>();
    }

    void FixedUpdate()
    {
        if(followPlayer)
        {
            positionX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref cameraVelocity.x, lagX);
            positionY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref cameraVelocity.y, lagY);
            transform.position = new Vector3(positionX + XOffset, positionY + YOffset, -10.0f);
        }
        
        if(boundsLock)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
                                             Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
                                             Mathf.Clamp(transform.position.z, minBounds.z, maxBounds.z));
        }   
    }

    void Update()
    {
        //float time = Mathf.PingPong(Time.time, timeSpeed) / timeSpeed;

        //if (mangekyouTimer <= 0.0f)
        //{
        //    theCamera.backgroundColor = Color.black;
        //}

        //if (mangekyouSharingan)
        //{
        //    if (mangekyouTimer >= 0.0f)
        //    {
        //        mangekyouTimer -= Time.deltaTime;
        //        theCamera.backgroundColor = Color.Lerp(color1, color2, time);
        //    }
        //}
    }
}
