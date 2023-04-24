using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;
    public Transform firePoint;
    private Animator anim;
    public GameObject Player;
    public int damage = 1;
    public GameObject bullet;

   

    void Die() 
    {
        Destroy(gameObject);
    }

    void Shoot() 
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            
        }
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
}
