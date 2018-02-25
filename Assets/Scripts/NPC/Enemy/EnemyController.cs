using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject enemyPrefab;

	//amount of seconds between each spawn/wave
	public int timeForSpawn = 30;
	public float speedMultiplier = 0.1f;
	private float currentSpeed = 1.0f;
	private int timeCounter = 0;
	private int enemyTotal = 10;
	private int enemyAddition = 3;

	//a list of all living enemies
	private List<ObjectStatus> enemies = new List<ObjectStatus>();

	private Vector3[] spawnPoints = new Vector3[2];

	/*
	public void SpawnEnemy(float health) {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(0, 42, 0), Quaternion.identity);
		Health enemyHealth = enemy.GetComponent<Health>();
		enemyHealth.MaxHealth = health;
		enemyHealth.CurrentHealth = health;
    }
    */

	//control waves, increase amount they get stronger, spawn enemies

	public void SpawnEnemy(float speedMulti, int spawnCaveIndex) {
		Vector3 spawnLocation = spawnPoints [spawnCaveIndex];
		spawnLocation.x += Random.Range (-1, 1);
		spawnLocation.z += Random.Range (-1, 1);
		GameObject currentEnemy = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
		currentEnemy.GetComponent<EnemyMovement>().SetSpeed(speedMulti);
		enemies.Add (currentEnemy.GetComponent<ObjectStatus> ());
    }

    private void Start() {
		timeCounter += timeForSpawn;
		spawnPoints [0] = new Vector3 (-316.15f, 42.02832f, 306.49f);
		spawnPoints [1] = new Vector3 (-575.23f, 45.53961f, -199.62f);
    }

	private void Update() {
		if (Time.time >= timeCounter) {
			print (timeCounter + " seconds have passed");
			int index = Random.Range (0, 2);
			for (int i = 0; i < enemyTotal; i++) {
				SpawnEnemy (currentSpeed, index);
			}
			enemyTotal += enemyAddition;
			currentSpeed += speedMultiplier;
			timeCounter += timeForSpawn;
		}
	}
}
