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

    private Vector3 minBoundsStored;
    private Vector3 maxBoundsStored;

    ////Level Specific
    //Level 1
    public bool level1PreStory;
    public int charToFollow;
    private FakeI fakeItachi;
    private FakeC fakeCyborg;
    private FakeS fakeSonic;
    public Transform platformCenterPoint;
    public bool explosionFlash;
    private float explosionTimer;
    private Color color1 = Color.black;
    private Color color2 = Color.white;
    private Camera theCamera;


    ////Private References
    private MasterController player;
    

	void Start () 
    {
        if(Application.loadedLevel == 7)
        {
            theCamera = GetComponent<Camera>();
            fakeItachi = FindObjectOfType<FakeI>();
            fakeCyborg = FindObjectOfType<FakeC>();
            fakeSonic = FindObjectOfType<FakeS>();
            //level1PreStory = true;
            explosionFlash = false;
            explosionTimer = 5.537f;
            charToFollow = 1;
        }

        //Auto Hook
        player = FindObjectOfType<MasterController>();
        minBoundsStored = minBounds;
        maxBoundsStored = maxBounds;
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
            switch(charToFollow)
            {
                case 0:
                    {
                        positionX = Mathf.SmoothDamp(transform.position.x, fakeItachi.transform.position.x, ref cameraVelocity.x, lagX);
                        positionY = Mathf.SmoothDamp(transform.position.y, fakeItachi.transform.position.y - 2.0f, ref cameraVelocity.y, lagY);
                        transform.position = new Vector3(positionX + XOffset, positionY + YOffset, -10.0f);
                        break;
                    }
                case 1:
                    {
                        positionX = Mathf.SmoothDamp(transform.position.x, fakeCyborg.transform.position.x, ref cameraVelocity.x, lagX);
                        positionY = Mathf.SmoothDamp(transform.position.y, fakeCyborg.transform.position.y - 2.0f, ref cameraVelocity.y, lagY);
                        transform.position = new Vector3(positionX + XOffset, positionY + YOffset, -10.0f);
                        break;
                    }
                case 2:
                    {
                        positionX = Mathf.SmoothDamp(transform.position.x, fakeSonic.transform.position.x, ref cameraVelocity.x, lagX);
                        positionY = Mathf.SmoothDamp(transform.position.y, fakeSonic.transform.position.y - 2.0f, ref cameraVelocity.y, lagY);
                        transform.position = new Vector3(positionX + XOffset, positionY + YOffset, -10.0f);
                        break;
                    }
                case 3:
                    {
                        positionX = Mathf.SmoothDamp(transform.position.x, platformCenterPoint.position.x, ref cameraVelocity.x, lagX);
                        positionY = Mathf.SmoothDamp(transform.position.y, platformCenterPoint.position.y - 2.0f, ref cameraVelocity.y, lagY);
                        if(explosionFlash)
                        {
                            transform.position = new Vector3(positionX + XOffset, positionY + YOffset, 0.0f);
                        }
                        else
                        {
                            transform.position = new Vector3(positionX + XOffset, positionY + YOffset, -10.0f);
                        }
                        
                        break;
                    }

            }

            float time = Mathf.PingPong(Time.time, 1.0f) / 1.0f;

            if (explosionFlash)
            {
                theCamera.clearFlags = CameraClearFlags.SolidColor;
                if (explosionTimer >= 0.0f)
                {
                    explosionTimer -= Time.deltaTime;
                    theCamera.backgroundColor = Color.Lerp(color1, color2, time);
                }
                if(explosionTimer <= 0.0f)
                {
                    theCamera.clearFlags = CameraClearFlags.Skybox;
                    explosionFlash = false;
                }
            }
            
        }
    }

    void Update()
    {
        
    }

    public void IncreaseYBounds()
    {
        maxBounds.y = -30.15f;
    }

    public void ResetYBounds()
    {
        maxBounds.y = maxBoundsStored.y;
    }
}
