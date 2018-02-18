using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {
	public GameObject wallPrefab;

	void Start() {
		ObjectHealth wallHealth = wallPrefab.GetComponent<ObjectHealth>();
		wallHealth.MaxHealth = 200;
		wallHealth.CurrentHealth = 200;
	}

}

