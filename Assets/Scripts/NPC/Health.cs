using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public delegate void DamageHandler(float amount);
    public event DamageHandler Damaged;

    public delegate void DiedHandler(Health context);
    public event DiedHandler Died;

    float _currentHealth = 100;

    float _maxHealth = 100;

    public float CurrentHealth {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, MaxHealth); }
    }

    public float MaxHealth {
        get { return _maxHealth; }
        set { _maxHealth = Mathf.Max(value, 0); }
    }

    public void Damage(float amount) {
        CurrentHealth -= amount;
        OnDamaged(amount);

        if (IsDead()) OnDied();
    }

    public bool IsDead() {
        return CurrentHealth <= 0; 
    }

    public void OnDamaged(float amount) {
        if (Damaged != null) Damaged(amount);
    }

    public void OnDied() {
        if (Died != null) Died(this);
    }
} 
