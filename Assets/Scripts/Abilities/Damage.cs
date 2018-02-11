using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
  
    private void OnCollisionEnter(Collision collision) {
        //Debug.Log("Bullet collided with " + collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy") {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            //Debug.Log("Current health: " + enemyHealth.CurrentHealth);
            enemyHealth.Damage(100);
            //Debug.Log("New health: " + enemyHealth.CurrentHealth);
            //Debug.Log("----------------------------------------");
        }
    }
}
