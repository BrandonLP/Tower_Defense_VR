using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject enemyPrefab;

	//amount of seconds between each spawn/wave
	public int timeForSpawn = 3;
	private int timeCounter = 0;

	//a list of all living enemies
	private List<ObjectStatus> enemies = new List<ObjectStatus>();

	/*
	public void SpawnEnemy(float health) {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(0, 42, 0), Quaternion.identity);
		Health enemyHealth = enemy.GetComponent<Health>();
		enemyHealth.MaxHealth = health;
		enemyHealth.CurrentHealth = health;
    }
    */

	//control waves, increase amount they get stronger, spawn enemies

	//add Transform spawnLocation as a field later
	//new Vector3(-316.15f, 42.02832f, 306.49f)
	public void SpawnEnemy(float speedMulti) {
		GameObject currentEnemy = Instantiate(enemyPrefab, new Vector3(-44.2f, 41.67f, -2.3f), Quaternion.identity);
		//currentEnemy.GetComponent<EnemyMovement>().SetSpeed(speedMulti);
		enemies.Add (currentEnemy.GetComponent<ObjectStatus> ());
    }

    private void Start() {
		timeCounter += timeForSpawn;
    }

	private void Update() {
		if (Time.time >= timeCounter) {
			timeCounter += timeForSpawn;
			SpawnEnemy (1.0f);
		}
	}
}
