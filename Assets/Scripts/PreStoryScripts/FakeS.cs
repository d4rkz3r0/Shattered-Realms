using UnityEngine;
using System.Collections;

public class FakeS : MonoBehaviour
{
    public LayerMask groundCheckLayer;
    private Transform groundChecker;

    private Rigidbody2D rb2D;
    private Animator anim;
    private SpriteRenderer sprRenderer;
    private float groundCheckRadius = 1.1f;
    public bool isGrounded;

    public bool event1;
    public bool moveToItachi;

    public Sprite hurtFrame;

    private FakeI fakeItachi;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
        groundChecker = GetComponentInChildren<Transform>();
        anim.enabled = false;
        fakeItachi = FindObjectOfType<FakeI>();
    }

    void FixedUpdate()
    {
        if(!moveToItachi)
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
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            sprRenderer.sprite = hurtFrame;
        }

        if (moveToItachi)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Animator>().SetFloat("Speed", 6.6f);
            GetComponent<Animator>().SetBool("isGrounded", true);
            GetComponent<Animator>().SetBool("isGoingSuper", false);
            transform.position = Vector3.MoveTowards(transform.position, fakeItachi.transform.position, 7.0f * Time.deltaTime);
        }
    }
}