﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallState : MonoBehaviour {

    public GameObject wallPartHigh;  // appearance of wall part at full health
    public GameObject wallPartMedium;  // appearance of wall part at 2/3 health
    public GameObject wallPartLow;  // appearance of wall part at 1/3 health
    
    private ObjectHealth _wallPartHealth;

    private Vector3 _wallPartPosition;
    private Quaternion _wallPartRotation;


    #region Properties
    public ObjectHealth WallPartHealth {
        get { return _wallPartHealth; }
        set { _wallPartHealth = value; }
    }

    public Vector3 WallPartPosition {
        get { return _wallPartPosition; }
        set { _wallPartPosition = value; }
    }

    public Quaternion WallPartRotation {
        get { return _wallPartRotation; }
        set { _wallPartRotation = value; }
    }
    #endregion

    private void Awake() {
        WallPartHealth = GetComponent<ObjectHealth>();
    }

    private void OnMouseDown() {
        WallPartPosition = transform.position;
        WallPartRotation = transform.rotation;

        WallPartHealth.Damage(10);
        print(WallPartHealth.CurrentHealth);
        CheckState();
    }

    public void CheckState() {
        if (!WallPartHealth.AtFullHealth()) {
            if (gameObject.tag == "WallHigh" && WallPartHealth.CurrentHealth <= WallPartHealth.MaxHealth / 3 * 2) 
                ChangeAppearance(wallPartMedium);

            if (gameObject.tag == "WallMedium" && WallPartHealth.CurrentHealth <= WallPartHealth.MaxHealth / 3) 
                ChangeAppearance(wallPartLow);
        }
    }

    // Change appearance of wall part
    public void ChangeAppearance(GameObject newState) {
        Instantiate(newState, WallPartPosition, WallPartRotation);
        Destroy(gameObject);
    }
}
