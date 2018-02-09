using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
  
    private void OnTriggerEnter(Collider collider) {
        Debug.Log("Bullet collided with " + collider.gameObject.name);
        if (collider.gameObject.tag == "Enemy") {
            Health enemyHealth = collider.gameObject.GetComponent<Health>();
            Debug.Log("Current health: " + enemyHealth.CurrentHealth);
            enemyHealth.Damage(10);
            Destroy(gameObject);
            Debug.Log("New health: " + enemyHealth.CurrentHealth);
            Debug.Log("----------------------------------------");
        }
    }
}
