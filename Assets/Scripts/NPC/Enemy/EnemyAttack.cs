using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    [SerializeField, Tooltip("Amount of damage done")]
    private float _baseDamage = 10;

    public float BaseDamage {
        get { return _baseDamage; }
        set { _baseDamage = value; }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Wall") {
            ObjectHealth damagedObjectHealth = collision.gameObject.GetComponent<ObjectHealth>();
            damagedObjectHealth.Damage(BaseDamage);
        }
    }
}
