// Author(s): Paul Calande
// Makes the attached object's angle move towards matching the main camera's angle.
// Works well for worldspace UI canvases.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedBillboard : MonoBehaviour
{
    // How quickly the object's angle changes.
    public float rotationSpeedMultiplier;

    // Change the speed of rotation based on how far away the destination is.
    private void Update()
    {
        Quaternion qMe = transform.rotation;
        Quaternion qCamera = Camera.main.transform.rotation;
        float rotationSpeed = Quaternion.Angle(qMe, qCamera) * rotationSpeedMultiplier * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(qMe, qCamera, rotationSpeed);
    }
}