using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampHealthbar : MonoBehaviour {
    public Slider healthbar;
	
	void Update () {
        Vector3 healthbarPos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthbar.transform.position = healthbarPos;
	}
}
