using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;

    public void TakeDamage(int damage) 
    {
        health -= damage;
        if (health <= 0) 
        {
            Die();
        }
    }

    void Die() 
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}