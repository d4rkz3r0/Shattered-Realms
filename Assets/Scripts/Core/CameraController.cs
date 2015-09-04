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

    ////Level Specific Camera Movement
    //Level 1
    private bool level1PreStory;
    private GameObject[] fakePlayers;



    ////Private References
    private MasterController player;
    

	void Start () 
    {
        if(Application.loadedLevel == 6)
        {
            fakePlayers[0] = GameObject.Find("FakeItachi");
            fakePlayers[1] = GameObject.Find("FakeCyborg");
            fakePlayers[2] = GameObject.Find("FakeSonic");
            level1PreStory = true;
        }

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

        if(level1PreStory)
        {
            positionX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref cameraVelocity.x, lagX);
            positionY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref cameraVelocity.y, lagY);
            transform.position = new Vector3(positionX + XOffset, positionY + YOffset, -10.0f);
        }
    }

    void Update()
    {
        
    }
}
