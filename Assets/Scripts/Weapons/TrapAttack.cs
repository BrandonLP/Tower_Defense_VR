using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class TrapAttack : MonoBehaviour {
    [SerializeField]
    int expectedDamage;

    int currentDamage;

	// Use this for initialization
	void Start () {
        GetComponent<VRTK_InteractableObject>().InteractableObjectSnappedToDropZone += new InteractableObjectEventHandler(SnappedToZone);
    }

    private void SnappedToZone(object sender, InteractableObjectEventArgs e)
    {
        currentDamage = expectedDamage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            ObjectHealth damagedObjectHealth = collision.gameObject.GetComponent<ObjectHealth>();
            damagedObjectHealth.Damage(currentDamage);
        }
    }
}
