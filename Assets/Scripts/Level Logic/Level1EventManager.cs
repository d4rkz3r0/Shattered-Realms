using UnityEngine;
using System.Collections;

public class Level1EventManager : MonoBehaviour
{
    //Event Objects
    private FakeI fakeItachi;
    private FakeC fakeCyborg;
    private FakeS fakeSonic;
    private Animator animI;
    private Animator animC;
    private Animator animS;
    private CameraController mainCamera;
    public bool startEvents;
    public int eventIndex;
    public GameObject ChatBoxHUDElement;

    public float eventTimer;
    private float eventDuration = 3.0f;
    private bool eventReset;

    //Event 1
    public AudioSource itachiEvn1SFX;
    public AudioSource sonicSuperSonicSFX;
    public AudioSource cyborgAhhSFX;
    public AudioSource fightSFX;
    public AudioSource finalExplosionSFX;
    public Transform rotationPoint;
    public float sonicDegreesPerSecond;
    public float cyborgDegreesPerSecond;
    public float itachiDegreesPerSecond;
    private Vector3 tempVec;
    private Vector3 tempVec1;
    private Vector3 tempVec2;
    public bool constantRotate;
    public bool increment;

	void Start ()
    {
        constantRotate = false;
        eventReset = false;
        eventIndex = 0;
        fakeItachi = FindObjectOfType<FakeI>();
        fakeCyborg = FindObjectOfType<FakeC>();
        fakeSonic = FindObjectOfType<FakeS>();
        animI = fakeItachi.GetComponent<Animator>();
        animC = fakeCyborg.GetComponent<Animator>();
        animS = fakeSonic.GetComponent<Animator>();
        mainCamera = FindObjectOfType<CameraController>();
	}
	
	void Update ()
    {
        if(cyborgDegreesPerSecond >= 960.0f)
        {
            cyborgDegreesPerSecond = 400.0f;
        }

        if (itachiDegreesPerSecond >= 960.0f)
        {
            itachiDegreesPerSecond = 400.0f;
        }

        if(sonicDegreesPerSecond <= -960.0f)
        {
            sonicDegreesPerSecond = -400.0f;
        }

        if(increment)
        {
            cyborgDegreesPerSecond += Random.RandomRange(1.0f, 10.0f);
            sonicDegreesPerSecond -= Random.RandomRange(1.0f, 10.0f);
            itachiDegreesPerSecond += Random.RandomRange(2.0f, 12.0f);
        }

        if (constantRotate)
        {
           increment = true;
           tempVec = Quaternion.AngleAxis (sonicDegreesPerSecond * Time.deltaTime, Vector3.forward) * tempVec;
           fakeSonic.transform.position = rotationPoint.position + tempVec;
           animS.SetBool("isGoingSuper", true);

           tempVec1 = Quaternion.AngleAxis(cyborgDegreesPerSecond * Time.deltaTime, Vector3.forward) * tempVec1;
           fakeCyborg.transform.position = rotationPoint.position + tempVec1;

           tempVec2 = Quaternion.AngleAxis(itachiDegreesPerSecond * Time.deltaTime, Vector3.forward) * tempVec2;
           fakeItachi.transform.position = rotationPoint.position + tempVec2;
        }

        if (startEvents == false)
        {
            eventTimer = eventDuration;
        }

        if (eventTimer >= 0.0f)
        {
            eventTimer -= Time.deltaTime;
        }

        if (eventTimer <= 0.0f)
        {
            if (eventIndex == 4)
            {
                eventIndex = -1;
                startEvents = false;
                return;
            }
            else
            {
                eventIndex++;
            }
        }


        if (startEvents)
        {
            switch (eventIndex)
            {

                case 0:
                    {
                        if (!eventReset)
                        {
                            fightSFX.Play();
                            animS.Play("sonic_SuperTransform");
                            sonicSuperSonicSFX.Play();
                            mainCamera.charToFollow = 3;
                            tempVec = fakeSonic.transform.position - rotationPoint.position;
                            tempVec1 = fakeSonic.transform.position - rotationPoint.position;
                            tempVec2 = fakeItachi.transform.position - rotationPoint.position;
                            constantRotate = true;
                            fakeCyborg.GetComponent<CircleCollider2D>().enabled = false;
                            fakeSonic.GetComponent<CircleCollider2D>().enabled = false;
                            fakeItachi.GetComponent<CircleCollider2D>().enabled = false;
                            animI.Play("itachi_AirStrike");
                            itachiEvn1SFX.Play();
                            cyborgAhhSFX.Play();
                            fakeCyborg.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                            animC.Play("Cyborg_Hover");
                            eventTimer = 0.01f;
                            eventReset = true;
                        }
                        break;
                    }
                case 1:
                    {
                        eventReset = false;
                        if (!eventReset && eventTimer <= 0.0f)
                        {
                            FindObjectOfType<Level1Waypoints>().startMoving = true;
                            

                            eventTimer = 7.6f;
                            eventReset = true;
                        }
                        break;
                    }
                case 2:
                    {
                        eventReset = false;
                        if (!eventReset && eventTimer <= 0.0f)
                        {
                            mainCamera.explosionFlash = true;
                            constantRotate = false;
                            increment = false;
                            
                            finalExplosionSFX.Play();
                            FindObjectOfType<Level1Waypoints>().startMoving = false;
                            animI.SetBool("toggleStatic", true);
                            animC.SetBool("toggleStatic", true);
                            animS.SetBool("toggleStatic", true);
                            animI.enabled = false;
                            animC.enabled = false;
                            animS.enabled = false;
                            fakeItachi.transform.position = new Vector3(-129.25f, -175.7606f, 0.0f);
                            fakeCyborg.transform.position = new Vector3(-125.08f, -175.7307f, 0.0f);
                            fakeSonic.transform.position = new Vector3(-119.75f, -176.0607f, 0.0f);
                            fakeCyborg.GetComponent<CircleCollider2D>().enabled = true;
                            fakeSonic.GetComponent<CircleCollider2D>().enabled = true;
                            fakeItachi.GetComponent<CircleCollider2D>().enabled = true;

                            eventTimer = 5.6f;
                            eventReset = true;
                        }
                        break;
                    }
                case 3:
                    {
                        eventReset = false;
                        if (!eventReset && eventTimer <= 0.0f)
                        {
                            fakeItachi.event1 = true;
                            fakeCyborg.event1 = true;
                            fakeSonic.event1 = true;
                            ChatBoxHUDElement.SetActive(true);
                            
                            eventTimer = 20.0f;
                            eventReset = true;
                        }
                        break;
                    }
                case 4:
                    {
                        eventReset = false;
                        if (!eventReset && eventTimer <= 0.0f)
                        {
                            gameObject.SetActive(false);
                            fakeItachi.event1 = false;
                            fakeCyborg.event1 = false;
                            fakeSonic.event1 = false;
                            eventTimer = 5.0f;
                            eventReset = true;

                        }
                        break;
                    }
            }
        }
	}
}
