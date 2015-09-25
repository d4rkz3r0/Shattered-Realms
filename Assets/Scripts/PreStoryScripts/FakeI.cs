using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FakeI : MonoBehaviour
{
    public LayerMask groundCheckLayer;
    private Transform groundChecker;

    private Rigidbody2D rb2D;
    private Animator anim;
    private SpriteRenderer sprRenderer;
    private float groundCheckRadius = 1.1f;
    public bool isGrounded;
    private CameraController mainCamera;

    public bool event1;
    public bool acceptChars;

    private bool member1collected;
    private bool member2collected;
    public GameObject thePlayer;
    public Sprite hurtFrame;
    public Sprite crowFrame;

    public Transform centerPoint;

    public AudioSource blinkSFX;

    private float eventTimer;

    private bool trigger0;
    private bool trigger;
    public GameObject UIComponents;
    public GameObject UITextLabels;
    public GameObject HPBar;
    public GameObject timerManager;
    public GameObject tutorialText;
    public GameObject LM;


    void Start()
    {
        trigger0 = false;
        trigger = false;
        member1collected = false;
        member2collected = false;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
        groundChecker = GetComponentInChildren<Transform>();
        mainCamera = FindObjectOfType<CameraController>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckRadius, groundCheckLayer);

    }

    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        anim.SetBool("isGrounded", isGrounded);


        if (eventTimer >= 0.0f)
        {
            eventTimer -= Time.deltaTime;
            anim.SetBool("isBlinking", true);
        }

        if (eventTimer <= 0.0f)
        {
            anim.SetBool("isBlinking", false);
            if (!trigger && member1collected && member2collected)
            {
                transform.position = centerPoint.position;
                anim.Play("itachi_CrowFade");
                trigger = true;
            }
        }

        if (event1)
        {
            sprRenderer.sprite = hurtFrame;
        }

        if (acceptChars)
        {
            sprRenderer.sortingOrder = 3;
        }

        if (member1collected && member2collected)
        {
            if (!trigger0)
            {
                blinkSFX.Play();
                trigger0 = true;
            }
            eventTimer = 0.5f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (acceptChars)
        {
            if (other.name == "FakeCyborg")
            {
                member1collected = true;
                other.gameObject.SetActive(false);
            }
            if (other.name == "FakeSonic")
            {
                member2collected = true;
                other.gameObject.SetActive(false);
            }
        }
    }

    public IEnumerator StartLevel1Gameplay()
    {
        UIComponents.SetActive(true);
        UITextLabels.SetActive(true);
        tutorialText.SetActive(true);
        timerManager.GetComponent<Text>().enabled = true;
        HPBar.GetComponent<Image>().enabled = true;
        HPBar.GetComponentInChildren<Text>().enabled = true;
        LM.SetActive(true);
        if(AudioManager.GetInstance() != null)
        {
            AudioManager.level1GameplayMusic();
        }
        mainCamera.level1PreStory = false;
        mainCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.278f, 0.459f, 0.588f, 1.0f);
        mainCamera.GetComponent<Camera>().orthographicSize = 7.0f; //Used to be 5.5
        mainCamera.minBounds = new Vector3(5.15f, -122.51f, -10.0f);
        mainCamera.maxBounds = new Vector3(543.44f, -105.6f, -10.0f);
        yield return new WaitForSeconds(0.1f);
        mainCamera.followPlayer = true;
        thePlayer.GetComponent<MasterController>().moveSpeed = 8.0f;
    }

    public void skipIntro()
    {
        FindObjectOfType<Level1EventManager>().gameObject.SetActive(false);
        GameObject.Find("ChatBox").gameObject.SetActive(false);
        MessageController.textSelection = 0;
        UIComponents.SetActive(true);
        UITextLabels.SetActive(true);
        tutorialText.SetActive(true);
        timerManager.GetComponent<Text>().enabled = true;
        HPBar.GetComponent<Image>().enabled = true;
        HPBar.GetComponentInChildren<Text>().enabled = true;
        LM.SetActive(true);
        if (AudioManager.GetInstance() != null)
        {
            AudioManager.level1GameplayMusic();
        }
        mainCamera.level1PreStory = false;
        mainCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.278f, 0.459f, 0.588f, 1.0f);
        mainCamera.GetComponent<Camera>().orthographicSize = 7.0f; //Used to be 5.5
        mainCamera.minBounds = new Vector3(5.15f, -122.51f, -10.0f);
        mainCamera.maxBounds = new Vector3(543.44f, -105.6f, -10.0f);
        mainCamera.followPlayer = true;
        thePlayer.GetComponent<MasterController>().moveSpeed = 8.0f;
        GameObject.Find("Skip Button").gameObject.SetActive(false);
    }
}