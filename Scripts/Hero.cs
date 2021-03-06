using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 5f;


    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private bool isGrounded;
    private float groundRadius = 0.3f;

    public Transform groundCheck;
    public LayerMask groundMask;
    public Joystick joystick;


    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }


    private void Update()
    {
        if (isGrounded) State = States.secidle;

        if (joystick.Horizontal != 0)
            Run();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
        if (joystick.Vertical > 0.5f && isGrounded)
        {
            rb.AddForce(new Vector2(0, 25));

        }
    }

    private void Run()
    {
        if (isGrounded) State = States.secwalking;
        Vector3 dir = transform.right * joystick.Horizontal;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }

}

public enum States
{

    secidle,
    secwalking
}

