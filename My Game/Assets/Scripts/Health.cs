using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    
    public float hp = 1f;
    public bool isEnemy = true;


    public void Damage(float damageCount) {
        hp -= damageCount;
        
        if (hp <= 0) {
            SpecialEffectsHelper.Instance.Explosion(transform.position);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Shot shot = other.gameObject.GetComponent<Shot>();
        if (shot != null) {
            if (shot.isEnemyShot != isEnemy) {
                Damage(shot.damage);
                Destroy(shot.gameObject);
            }
        }
    }
}