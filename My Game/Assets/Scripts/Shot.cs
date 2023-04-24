using UnityEngine;

public class Shot : MonoBehaviour {
    public int damage = 1;
    public bool isEnemyShot = false;
    public Rigidbody2D  rb;
    public float speed = 5f;
    
    // Start is called before the first frame update
    void Start() {

        rb.velocity = transform.right * speed;
        Destroy(gameObject, 20);
    }

}
