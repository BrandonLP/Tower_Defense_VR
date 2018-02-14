using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStatus : MonoBehaviour {
	Health _wallHealth;

	void Awake() {
		_wallHealth = GetComponent<Health>();
		_wallHealth.Died += delegate(Health context) {
			Destroy(context.gameObject);
		};
	}

}
