using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour {
    [Tooltip("Amount of health gained back")]
    private float _healAmount;

    private ObjectHealth _health;

    #region Properties
    public float HealAmount {
        get { return _healAmount; }
        set { _healAmount = value; }
    }

    public ObjectHealth Health {
        get { return _health; }
        set { _health = value; }
    }
    #endregion

    private void Awake() {
        Health = gameObject.GetComponent<ObjectHealth>();
        HealAmount = Health.MaxHealth * (float)0.5;
    }

    public void Heal() {
        //Debug.Log("\n-----\nHealth before healing: " + Health.CurrentHealth);
        Health.Heal(HealAmount);
        Debug.Log("\nHealth after healing: " + Health.CurrentHealth + "\n-----\n");
    }

    /*
    public void OnMouseDown() {
        Heal();
    }*/
}
