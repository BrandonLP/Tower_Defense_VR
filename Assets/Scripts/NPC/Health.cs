using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public delegate void DamageHandler(float amount);
    public event DamageHandler Damaged;

    public delegate void DiedHandler(Health context);
    public event DiedHandler Died;

    public delegate void HealedHandler(float amount);
    public event HealedHandler Healed;

	[SerializeField, Tooltip("Current health value")]
    float _currentHealth = 100;

	[SerializeField, Tooltip("Max health value")]
    float _maxHealth = 100;

    // For debugging - delete when finished testing
    // if true, heal
    // if false, damage
    public bool Flip = false;

    public float CurrentHealth {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, MaxHealth); }
    }

    public float MaxHealth {
        get { return _maxHealth; }
        set { _maxHealth = Mathf.Max(value, 0); }
    }

    /// <summary>Health value went down.</summary>
    public void Damage(float amount) {
        if (amount > 0 && !IsDead()) {
            CurrentHealth -= amount;
            OnDamaged(amount);
        }
        if (IsDead()) OnDied();
    }

    /// <summary>Health value went up.</summary>
    public void Heal(float amount) {
        if (amount > 0 && !AtFullHealth()) {
            CurrentHealth += amount;
            OnHealed(amount);
        }
    }

    /// <summary>Health value is equal to/more than the max health value.</summary>
    public bool AtFullHealth() {
        return CurrentHealth >= MaxHealth;
    }

    /// <summary>Health value is equal to/less than zero.</summary>
    public bool IsDead() {
        return CurrentHealth <= 0; 
    }

    public void OnDamaged(float amount) {
        if (Damaged != null) Damaged(amount);
    }

    public void OnDied() {
        if (Died != null) Died(this);
    }

    public void OnHealed(float amount) {
        if (Healed != null) Healed(amount);
    }
} 
