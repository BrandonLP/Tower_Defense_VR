using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeBehavior : MonoBehaviour, GazeReceiver {
    // Modified from http://www.immersivelimit.com/detect-when-looking-at-object/
    // Goes on the object the player is gazing at

    public float delayTime = 1.5f;

    public GameObject instructionsPanel;

    private bool isGazingUpon;

    void Update () {
        if (isGazingUpon) {
            //Debug.Log("looking");
            Invoke("EnableInstructions", delayTime);
            this.enabled = false; // disable raycasting so instructions don't pop up again every time player looks at shop after
        }
    }

    public void EnableInstructions() {
        instructionsPanel.SetActive(true);
    }

    public void GazingUpon() {
        isGazingUpon = true;
    }

    public void NotGazingUpon() {
        isGazingUpon = false;
    }

}