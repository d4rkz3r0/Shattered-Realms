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
    private FakeI fakeItachi;
    private FakeC fakeCyborg;
    private FakeS fakeSonic;



    ////Private References
    private MasterController player;
    

	void Start () 
    {
        fakeItachi = FindObjectOfType<FakeI>();
        fakeCyborg = FindObjectOfType<FakeC>();
        fakeSonic = FindObjectOfType<FakeS>();

        if(Application.loadedLevel == 6)
        {
            fakeItachi = FindObjectOfType<FakeI>();
            fakeCyborg = FindObjectOfType<FakeC>();
            fakeSonic = FindObjectOfType<FakeS>();
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
            positionX = Mathf.SmoothDamp(transform.position.x, fakeCyborg.transform.position.x, ref cameraVelocity.x, lagX);
            positionY = Mathf.SmoothDamp(transform.position.y, fakeCyborg.transform.position.y - 2.0f, ref cameraVelocity.y, lagY);
            transform.position = new Vector3(positionX + XOffset, positionY + YOffset, -10.0f);
        }
    }

    void Update()
    {
        
    }
}
