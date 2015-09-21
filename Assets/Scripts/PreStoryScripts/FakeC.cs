using UnityEngine;
using System.Collections;

public class FakeC : MonoBehaviour
{
    public LayerMask groundCheckLayer;
    private Transform groundChecker;

    private Rigidbody2D rb2D;
    private Animator anim;
    private SpriteRenderer sprRenderer;
    private float groundCheckRadius = 1.5f;
    public bool isGrounded;

    public bool event1;
    public bool moveToItachi;

    public Sprite hurtFrame;
    private FakeI fakeItachi;


    void Start()
    {
        moveToItachi = false;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
        groundChecker = GetComponentInChildren<Transform>();
        fakeItachi = FindObjectOfType<FakeI>();
    }

    void FixedUpdate()
    {
        if (!moveToItachi)
        {
            isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckRadius, groundCheckLayer);
        }
        else
        {
            return;
        }

    }

    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

        if (event1)
        {
            sprRenderer.sprite = hurtFrame;
        }

        if(moveToItachi)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Animator>().SetFloat("Speed", 1.0f);
            GetComponent<Animator>().SetBool("isGrounded", true);
            transform.position = Vector3.MoveTowards(transform.position, fakeItachi.transform.position, 1.85f * Time.deltaTime);
        }



    }
}