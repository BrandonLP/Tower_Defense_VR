using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    [SerializeField, Tooltip("Amount of damage done")]
    float _damageValue = 10;

    public float DamageValue {
        get { return _damageValue; }
        set { _damageValue = value; }
    }
  
    /*
    private void OnCollisionEnter(Collision collision) {
        //Debug.Log("Bullet collided with " + collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player") {
            Health health = collision.gameObject.GetComponent<Health>();
            Debug.Log("Health before damaged: " + health.CurrentHealth);
            health.Damage(DamageValue);
            Debug.Log("Health after damaged: " + health.CurrentHealth);
            //Debug.Log("----------------------------------------");
        }
    }*/

    private void OnMouseDown() {
        if (gameObject.tag == "Enemy" || gameObject.tag == "Player") {
            Health health = gameObject.GetComponent<Health>();
            if (!health.Flip) {
                Debug.Log("\n*****\nHealth before damaged: " + health.CurrentHealth);
                health.Damage(DamageValue);
                Debug.Log("\nHealth after damaged: " + health.CurrentHealth + "\n*****\n");
                if (health.CurrentHealth <= 50) {
                    health.Flip = true;
                }
            }
        }
    }
}
