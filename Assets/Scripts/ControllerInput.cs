using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class ControllerInput : MonoBehaviour {
    private void Start() {
        /*if (GetComponent<VRTK_ControllerEvents>() == null) {
            Debug.LogError("Need to have VRTK_ControllerEvents component attached to the controller");
            return;
        }*/
        GetComponent<VRTK_ControllerEvents>().TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
    }

    private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e) {
        GetComponentInParent<Healing>().Heal();
    }
}
