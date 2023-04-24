using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : MonoBehaviour
{

    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
    public Transform groundCheck;
    public Transform firePoint;
    public Transform checkPlayer;
    public GameObject Player;
    bool isFacingRight = true;
    RaycastHit2D groundHit;
    //RaycastHit2D hitInfo;
    RaycastHit2D playerInfo;
    private Animator anim;
    public float hitDistance;
    //public LineRenderer lineRenderer;
    public GameObject obj;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        groundHit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundLayers);
        //hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, hitDistance);
        playerInfo = Physics2D.Raycast(checkPlayer.position, checkPlayer.right, hitDistance);
        

        if (!playerInfo)
        {

            if (groundHit.collider != false)
            {
                anim.SetBool("run", true);
                if (isFacingRight)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
            }
            else
            {
                isFacingRight = !isFacingRight;
                transform.Rotate(0f, 180f, 0f);
            }

            //lineRenderer.SetPosition(0, checkPlayer.position);
            //lineRenderer.SetPosition(1, checkPlayer.position + checkPlayer.right * hitDistance);
        }
       else 
        {
            /*lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);*/
            Weapon weapon = GetComponent<Weapon>();
            
                anim.SetBool("run", false);
                if (weapon != null)
                {
                    weapon.Attack(false);
                }  
        }
    }
}