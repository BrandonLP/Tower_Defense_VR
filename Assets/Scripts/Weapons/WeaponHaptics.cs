using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class WeaponHaptics : MonoBehaviour {

    public GameObject controller;

    private VRTK_InteractableObject interactableObject;

    private void Start() {
        interactableObject = GetComponent<VRTK_InteractableObject>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (interactableObject.IsGrabbed() && collision.gameObject.tag == "Enemy") {
            VRTK_InteractHaptics interactHaptics = GetComponent<VRTK_InteractHaptics>();
            interactHaptics.HapticsOnGrab(VRTK_ControllerReference.GetControllerReference(controller));
        }
    }
}
