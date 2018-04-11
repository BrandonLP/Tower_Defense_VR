using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * @author Stephanie Xie
 * 
 * Health script.
 */
public class ObjectHealth : MonoBehaviour {
    [Tooltip("Current health value")]
    private float _currentHealth;

    [Tooltip("Max health value")]
    private float _maxHealth = 100;

    [Tooltip("Health bar")]
    public Slider healthbar;

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

    private void Awake() {
        CurrentHealth = MaxHealth;
    }

    // Health value is equal to/more than the max health value.
    public bool AtFullHealth() {
        return CurrentHealth >= MaxHealth;
    }

    // Calculate current health percentage (for health bar).
    public float CalculateHealth() {
        return CurrentHealth / MaxHealth;
    }

    // Health value went down.
    public void Damage(float amount) {
        if (amount > 0 && !IsDead()) {
            CurrentHealth -= amount;
            UpdateHealthbar();
            OnDamaged(amount);
        }
        if (IsDead()) OnDied();
    }

    // Health value went up.
    public void Heal(float amount) {
        if (amount > 0 && !AtFullHealth()) {
            CurrentHealth += amount;
            UpdateHealthbar();
            OnHealed(amount);
        }
    }

    // Health value is equal to/less than zero.
    public bool IsDead() {
        return CurrentHealth <= 0; 
    }

    public void UpdateHealthbar() {
        if (healthbar != null) {
            healthbar.value = CalculateHealth();
        }
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
