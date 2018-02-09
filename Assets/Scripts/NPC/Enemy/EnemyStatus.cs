using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {
    Health _enemyHealth;

    void Awake() {
        _enemyHealth = GetComponent<Health>();
        _enemyHealth.Died += delegate(Health context) {
            Destroy(context.gameObject);
        };
    }
    
}
