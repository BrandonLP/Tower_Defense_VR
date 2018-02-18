using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour {
    [SerializeField, Tooltip("Current health value")]
    private float _currentHealth = 100;

    [SerializeField, Tooltip("Max health value")]
    private float _maxHealth = 100;

    #region Events
    public delegate void DamageHandler(float amount);
    public event DamageHandler Damaged;

    public delegate void DiedHandler();
    public event DiedHandler Died;

    public delegate void HealedHandler(float amount);
    public event HealedHandler Healed;
    #endregion

    #region Properties
    public float CurrentHealth {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, MaxHealth); }
    }

    public float MaxHealth {
        get { return _maxHealth; }
        set { _maxHealth = Mathf.Max(value, 0); }
    }
    #endregion

    /// <summary>Health value is equal to/more than the max health value.</summary>
    public bool AtFullHealth() {
        return CurrentHealth >= MaxHealth;
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

    /// <summary>Health value is equal to/less than zero.</summary>
    public bool IsDead() {
        return CurrentHealth <= 0; 
    }

    private void OnDamaged(float amount) {
        if (Damaged != null) Damaged(amount);
    }

    private void OnDied() {
        if (Died != null) Died();
    }

    private void OnHealed(float amount) {
        if (Healed != null) Healed(amount);
    }
} 
