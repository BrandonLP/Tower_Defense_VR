using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject enemyPrefab;

	//amount of seconds between each spawn/wave
	public float timeForSpawn = 3f;
	private float timeCounter = 0f;

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
	public void SpawnEnemy(float speedMulti) {
		GameObject currentEnemy = Instantiate(enemyPrefab, new Vector3(-316.15f, 42.02832f, 306.49f), Quaternion.identity);
		EnemyMovement eMovement = currentEnemy.GetComponent<EnemyMovement> ();
		//eMovement.SetSpeed(speedMulti);
		enemies.Add (currentEnemy.GetComponent<ObjectStatus> ());
    }

    private void Start() {
		SpawnEnemy (1.0f);
		timeCounter += timeForSpawn;
    }

	private void Update() {
		//if (Time.time >= timeCounter) {
			//SpawnEnemy (1.0f);
			//timeCounter += timeForSpawn;
		//}
	}
}
