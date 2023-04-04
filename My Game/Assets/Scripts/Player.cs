using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private float input;
    private float inputY;
    public float jumpForce;
    
    private Rigidbody2D rb;
    public bool turning = true;
    private Animator anim;

    private bool isGrounted;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJump;
    public int extraJumpValue;

    int count;

    // Start is called before the first frame update
    void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounted = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        input = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        Run();
        if (turning == false && input > 0)
        {
            Flip();
        }
        else if (turning == true && input < 0)
        {
            Flip();
        }

        Jump();

        Shoot();


        //var dist = (transform.position - Camera.main.transform.position).z;

        //var leftBorder = Camera.main.ViewportToWorldPoint(
        //    new Vector3(0, 0, dist)
        //).x;

        //var rightBorder = Camera.main.ViewportToWorldPoint(
        //    new Vector3(1, 0, dist)
        //).x;

        //var topBorder = Camera.main.ViewportToWorldPoint(
        //    new Vector3(0, 0, dist)
        //).y;

        //var bottomBorder = Camera.main.ViewportToWorldPoint(
        //    new Vector3(0, 1, dist)
        //).y;

        //transform.position = new Vector3(
        //    Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
        //    Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
        //    transform.position.z
        //);

        

    }

    private void Run() 
    {
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
        if (input == 0)
        {
            anim.SetBool("run", false);
        }
        else
        {
            anim.SetBool("run", true);
        }
    }

    private void Jump() 
    {
        if (isGrounted == true)
        {
            extraJump = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump > 0)
        {
            anim.SetTrigger("jump");
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (inputY == 1 && extraJump == 0 && isGrounted == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void Shoot() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("shoot");
        }
        else {
            anim.SetBool("idle", true);
        }
    }

    private void Flip()
    {
        turning = !turning;
        transform.Rotate(0f, 180f, 0f);
        //Vector3 Scaler = transform.localScale;
        //Scaler.x *= -1;
        //transform.localScale = Scaler;
    }


}
