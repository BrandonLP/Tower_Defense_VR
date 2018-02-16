using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {
    [SerializeField, Tooltip("Amount of health gained back")]
    float _healthValue = 5;

    public float HealthValue {
        get { return _healthValue; }
        set { _healthValue = value; }
    }

    public void OnMouseDown() {
        if (gameObject.tag == "Player") {
            Health health = gameObject.GetComponent<Health>();
            if (health.Flip) {
                Debug.Log("\n-----\nHealth before healing: " + health.CurrentHealth);
                health.Heal(HealthValue);
                Debug.Log("\nHealth after healing: " + health.CurrentHealth + "\n-----\n");
                if (health.AtFullHealth()) {
                    health.Flip = false;
                }
            }
        }
    }

}
