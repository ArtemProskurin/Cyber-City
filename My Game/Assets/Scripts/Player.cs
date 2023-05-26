using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

       
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        if (shoot) {
            Weapon weapon = GetComponent<Weapon>();
            if (weapon != null) {
                anim.SetTrigger("shoot");
                weapon.Attack(false);
                //SoundEffectsHelper.Instance.MakePlayerShotSound();
            }
        }
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

    void OnDestroy() {
       SceneManager.LoadScene("GameOver");
    }

    

    private void Flip()
    {
        turning = !turning;
        transform.Rotate(0f, 180f, 0f);
    }
}
