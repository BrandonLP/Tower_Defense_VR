using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject enemyPrefab;

	/*
	public void SpawnEnemy(float health) {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(0, 42, 0), Quaternion.identity);
		Health enemyHealth = enemy.GetComponent<Health>();
		enemyHealth.MaxHealth = health;
		enemyHealth.CurrentHealth = health;
    }
    */

	public void SpawnEnemy() {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(10, 0, 0), Quaternion.identity);
    }

    private void Start() {
        SpawnEnemy();
    }
}
