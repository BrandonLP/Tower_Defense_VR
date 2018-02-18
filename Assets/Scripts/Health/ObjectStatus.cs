using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatus : MonoBehaviour {
    public delegate void DiedHandler();
    public event DiedHandler Died;

    private ObjectHealth _health;

    public ObjectHealth Health {
        get { return _health; }
        set { _health = value; }
    }

    private void Awake() {
        Health = GetComponent<ObjectHealth>();
        Health.Died += Die;
    }
    
    private void Die() {
        OnDied();
        Destroy(gameObject);
    }

    private void OnDied() {
        if (Died != null) Died();
    }
}
