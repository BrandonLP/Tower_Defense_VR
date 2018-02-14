using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {
	public GameObject wallPrefab;

	void Start() {
		Health wallHealth = wallPrefab.GetComponent<Health>();
		wallHealth.MaxHealth = 200;
		wallHealth.CurrentHealth = 200;
	}

}

