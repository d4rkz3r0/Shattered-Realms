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

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
        groundChecker = GetComponentInChildren<Transform>();
        anim.enabled = false;
        //transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckRadius, groundCheckLayer);

    }

    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }
}