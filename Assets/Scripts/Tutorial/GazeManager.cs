using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeManager : MonoBehaviour {
    // Modified from http://www.immersivelimit.com/detect-when-looking-at-object/

    private GameObject lastGazedUpon;
	
	// Update is called once per frame
	void Update () {
        CheckGaze();
	}

    private void CheckGaze() {
        if (lastGazedUpon) {
            lastGazedUpon.SendMessage("NotGazingUpon", SendMessageOptions.DontRequireReceiver);
        }

        //Ray gazeRay = new Ray(VRTK.VRTK_DeviceFinder.HeadsetTransform().position, VRTK.VRTK_DeviceFinder.HeadsetTransform().rotation * Vector3.forward);
        Vector3 startOfRay = VRTK.VRTK_DeviceFinder.HeadsetTransform().position;
        Vector3 directionOfRay = VRTK.VRTK_DeviceFinder.HeadsetTransform().rotation * Vector3.forward;
        RaycastHit hit;
        //if (Physics.Raycast(gazeRay, out hit, Mathf.Infinity)) {
        if (Physics.SphereCast(startOfRay, 5f, directionOfRay, out hit, Mathf.Infinity)) {
            //Debug.DrawRay(VRTK.VRTK_DeviceFinder.HeadsetTransform().position, VRTK.VRTK_DeviceFinder.HeadsetTransform().rotation * Vector3.forward, Color.red);
            hit.transform.SendMessage("GazingUpon", SendMessageOptions.DontRequireReceiver);
            lastGazedUpon = hit.transform.gameObject;
        }
    }
}
