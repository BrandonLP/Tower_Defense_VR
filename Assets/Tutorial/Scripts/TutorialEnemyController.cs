using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using VRTK;

public class TutorialEnemyController : MonoBehaviour {
    public GameObject enemyPrefab;

	//points that the enemy is worth
	private int points = 2;

    private void Start() {
        GameObject currentEnemy = Instantiate(enemyPrefab, new Vector3 (-50f, 43f, -3f), Quaternion.identity);
        currentEnemy.GetComponent<EnemyMovement>().SetPointVal(points);
        currentEnemy.GetComponent<EnemyMovement>().SetPointVal(points);
    }

}
