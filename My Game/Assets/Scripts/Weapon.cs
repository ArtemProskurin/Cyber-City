using UnityEngine;

public class Weapon : MonoBehaviour {
    public GameObject bullet;
    public Transform firePoint;
    // public Transform shotPrefab;
    public float shootingRate = 0.25f;
    private float shootCooldown;
    

    
    void Start() {
        shootCooldown = 0f;
    }

    
    void Update() {
        if (shootCooldown > 0) {
            shootCooldown -= Time.deltaTime;
        }
        
    }

    public void Attack(bool isEnemy) {
        if (CanAttack) {
            shootCooldown = shootingRate;
            var shotTransform = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Shot shot = shotTransform.gameObject.GetComponent<Shot>();
            if (shot != null) {
                shot.isEnemyShot = isEnemy;
            }
        }
    }

    public bool CanAttack {
        get {
            return shootCooldown <= 0f;
        }
    }
}