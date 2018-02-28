using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillHealthBar : MonoBehaviour {

	void Start() {
        GameObject gameOverParent = transform.parent.gameObject;
        GameObject healthHUD = gameOverParent.transform.Find("UICanvas").gameObject;
        healthHUD.SetActive(false);
	}
}
