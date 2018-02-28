using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ShopMechanics : MonoBehaviour {
	[Tooltip("How much the item costs")]
	private int _price;

	// Use this for initialization
	void Start () {
		GetComponent<VRTK_InteractableObject>().InteractableObjectUnsnappedFromDropZone += new InteractableObjectEventHandler(UnsnappedFromZone);
	}

	private void UnsnappedFromZone(object sender, InteractableObjectEventArgs e) {
		if (GameObject.Find ("EnemyController").GetComponent<PointTracker> ().currentPoints >= _price) {
			GameObject.Find ("EnemyController").GetComponent<PointTracker> ().currentPoints -= _price;
		} else {
			Destroy (this);
		}
	}
}
