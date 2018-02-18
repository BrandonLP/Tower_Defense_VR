using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamage : MonoBehaviour {
    [SerializeField, Tooltip("Amount of damage done")]
    private float _damageAmount = 10;

    private GameObject _objectDamaged;

    #region Properties
    public float DamageAmount {
        get { return _damageAmount; }
        set { _damageAmount = value; }
    }

    public GameObject ObjectDamaged {
        get { return _objectDamaged; }
        set { _objectDamaged = value; }
    }
    #endregion

    public void Damage() {
        ObjectHealth objectHealth = ObjectDamaged.GetComponent<ObjectHealth>();
        Debug.Log("\n*****\nHealth before damaged: " + objectHealth.CurrentHealth);
        objectHealth.Damage(DamageAmount);
        Debug.Log("\nHealth after damaged: " + objectHealth.CurrentHealth + "\n*****\n");
    }

    private void OnCollisionEnter(Collision collision) {
        //Debug.Log("Sword collided with " + collision.gameObject.name);
        ObjectDamaged = collision.gameObject;
        if (ObjectDamaged.tag == "Enemy" || ObjectDamaged.tag == "Player" || ObjectDamaged.tag == "Wall")
            Damage();
    }

    /*
    private void OnMouseDown() {
        ObjectDamaged = gameObject;
        if (ObjectDamaged.tag == "Enemy" || ObjectDamaged.tag == "Player" || ObjectDamaged.tag == "Wall")
            Damage();
    }*/
}
