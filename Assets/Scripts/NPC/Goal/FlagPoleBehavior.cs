using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlagPoleBehavior : MonoBehaviour {

    private bool _enemyTouchingFlagPole;

    private Vector3 _poleBottomPosition;

    public bool EnemyTouchingFlagPole {
        get { return _enemyTouchingFlagPole; }
        set { _enemyTouchingFlagPole = value; }
    }

    private void Start() {
        EnemyTouchingFlagPole = false;
    }

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Enemy") {
            EnemyTouchingFlagPole = true;
		}
	}

	private void OnCollisionExit(Collision collision) {
		if (collision.gameObject.tag == "Enemy") {
            EnemyTouchingFlagPole = false;
		}
	}

}
