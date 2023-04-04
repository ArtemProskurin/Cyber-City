using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotRun : MonoBehaviour
{

    public Vector2 speed = new Vector2(-1, 10);
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        movement = new Vector2(
            speed.x, 0);
    }


    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
