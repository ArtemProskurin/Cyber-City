using UnityEngine;

public class Shot : MonoBehaviour {
    public float damage = 0.25f;
    public bool isEnemyShot = false;
    public Rigidbody2D  rb;
    public float speed = 5f;
    
    // Start is called before the first frame update
    void Start() {

        rb.velocity = transform.right * speed;
        Destroy(gameObject, 20);
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
	{
		Boss_Health enemy = hitInfo.GetComponent<Boss_Health>();
		if (enemy != null)
		{
			enemy.Damage(damage);
		}

		Destroy(gameObject);
	}
}
