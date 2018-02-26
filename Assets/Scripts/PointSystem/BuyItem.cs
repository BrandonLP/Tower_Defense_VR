using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour {
	[Tooltip("How much the item costs")]
	private int _price;

	[Tooltip("Name of Snap Drop Zone in the hierarchy")]
	private string _snapName;

	// Use this for initialization
	void Start () {
		//Event snapHandler = GameObject.Find (_snapName).GetComponent<VRTK.VRTK_SnapDropZone> ().OnObjectUnsnappedFromDropZone;
	}

	// Update is called once per frame
	void Update () {
		//if (snapHandler != null && GameObject.Find("EnemyController").GetComponent<PointTracker>().currentPoints >= _price) {
		//	GameObject.Find ("EnemyController").GetComponent<PointTracker> ().currentPoints -= _price;
		//}
	}
}
