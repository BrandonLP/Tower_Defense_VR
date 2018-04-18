using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class InstructionsController : MonoBehaviour {

    public GameObject leftController;
    public GameObject rightController;
    private VRTK_Pointer lcPointer;
    private VRTK_Pointer rcPointer;

    public GameObject player;

    private bool _doInteractGrab;

    private GameObject instructionsGO;
    private InstructionsOnClick instructions;

    private ObjectHealth playerHealth;

    public GameObject tutorialEnemyControllerPrefab;
    private GameObject tutorialEnemyController;

    private void Start() {
        leftController.GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadPressed);
        rightController.GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadPressed);

        leftController.GetComponent<VRTK_ControllerEvents>().TouchpadReleased += new ControllerInteractionEventHandler(DoTouchpadReleased);
        rightController.GetComponent<VRTK_ControllerEvents>().TouchpadReleased += new ControllerInteractionEventHandler(DoTouchpadReleased);

        leftController.GetComponent<VRTK_ControllerEvents>().ButtonTwoReleased += new ControllerInteractionEventHandler(DoButtonTwoReleased);
        rightController.GetComponent<VRTK_ControllerEvents>().ButtonTwoReleased += new ControllerInteractionEventHandler(DoButtonTwoReleased);

        rightController.GetComponent<VRTK_InteractGrab>().ControllerGrabInteractableObject += new ObjectInteractEventHandler(DoInteractGrab);

        rcPointer = rightController.GetComponent<VRTK_Pointer>();
        lcPointer = leftController.GetComponent<VRTK_Pointer>();

        instructionsGO = transform.GetChild(0).gameObject;
        instructions = instructionsGO.GetComponent<InstructionsOnClick>();

        playerHealth = player.GetComponent<ObjectHealth>();

        tutorialEnemyController = Instantiate(tutorialEnemyControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        tutorialEnemyController.GetComponent<TutorialEnemyController>().enabled = false;

        StartCoroutine(NeedHealingAlert());
    }
        
    IEnumerator NeedHealingAlert() {
        while (true) {
            while (!playerHealth.AtFullHealth()) {
                yield return null;
            }

            while (playerHealth.AtFullHealth()) {
                yield return null;
            }

            instructions.EnableInstructions(3);

            yield break;
        }
    }

    private void DoTouchpadPressed(object sender, ControllerInteractionEventArgs e) {
        if (instructionsGO.activeSelf) {
            // if instructions are on screen, disable pointer and teleport
            rcPointer.enabled = false;
            lcPointer.enabled = false;
        } else {
            rcPointer.enabled = true;
            lcPointer.enabled = true;
        }
    }

    private void DoTouchpadReleased(object sender, ControllerInteractionEventArgs e) {
        if (instructionsGO.activeSelf && instructions.Current < 4) {
            instructions.NextInstruction();
        }

        if (instructions.Current == 3) {
            instructions.DisableInstructions();
        }

        if (instructions.Current == 4) {
            instructions.DisableInstructions();
            tutorialEnemyController.GetComponent<TutorialEnemyController>().enabled = true;
        }
    }

    private void DoButtonTwoReleased(object sender, ControllerInteractionEventArgs e) {
        if (instructions.Current == 5) {
            SceneLoader.LoadMenu();
        }
    }

    private void DoInteractGrab(object sender, ObjectInteractEventArgs e) {
        /*
        if (e.target) {
            DebugInteractLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRABBING", e.target);
        }
        */
        if (e.target.tag == "Weapon" && !_doInteractGrab) {
            _doInteractGrab = true;  // prevent "Using the TOUCHPAD..." from popping up if picking up sword again
            instructions.EnableInstructions(2);
        }
    }

    /*
    private void DebugInteractLogger(uint index, string action, GameObject target) {
        VRTK_Logger.Info("Controller on index '" + index + "' is " + action + " an object named " + target.name);
    }
    */
}
