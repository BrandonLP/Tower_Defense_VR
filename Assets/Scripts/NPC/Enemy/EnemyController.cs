﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject enemyPrefab;

	//amount of seconds between each spawn/wave
	public int timeForSpawn = 30;

	private int timeCounter = 0;

	//how much the mobs speed increase w/each wave
	public float speedMultiplier = 0.1f;

	//the speed of the current mob spawning
	private float currentSpeed = 1.0f;

	//every 4 seconds the location of the player is resent to all enemies
	private int timeLocationTracker = 4;

	private int timeLTCounter = 0;

	//amt of enemies spawned this wave
	private int enemyTotal = 10;

	//amt of enemies that increase each wave
	private int enemyAddition = 3;

	//a list of all living enemies
	private List<ObjectStatus> enemies = new List<ObjectStatus>();

	//the cave spawn locations
	private Vector3[] spawnPoints = new Vector3[2];

	//points that the enemy is worth
	private int points = 1;

	//inc that the points increase with mob strength
	private int pointsInc = 1;

	private Vector3 currentPlayerLocation;

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
		currentEnemy.GetComponent<EnemyMovement> ().SetPointVal (points);
		enemies.Add (currentEnemy.GetComponent<ObjectStatus> ());
    }

    private void Start() {
		timeCounter += timeForSpawn;
		timeLTCounter += timeLocationTracker;
		spawnPoints [0] = new Vector3 (-313.96f, 40.19f, 306.44f);
		spawnPoints [1] = new Vector3 (-575.5f, 45.042f, -197.88f);
		currentPlayerLocation = VRTK.VRTK_DeviceFinder.HeadsetTransform ().position;
    }

	private void Update() {
		if (Time.time >= timeCounter) {
			int index = Random.Range (0, 2);
			for (int i = 0; i < enemyTotal; i++) {
				SpawnEnemy (currentSpeed, index);
			}
			enemyTotal += enemyAddition;
			currentSpeed += speedMultiplier;
			points += pointsInc;
			timeCounter += timeForSpawn;
		}
		if (Time.time >= timeLTCounter) {
			if (currentPlayerLocation != VRTK.VRTK_DeviceFinder.HeadsetTransform ().position) {
				for (int i = 0; i < enemies.Count; i++) {
					currentPlayerLocation = VRTK.VRTK_DeviceFinder.HeadsetTransform ().position;
					enemies [i].GetComponent<EnemyMovement> ().SetDestination (currentPlayerLocation);
				}
			}
			timeLTCounter += timeLocationTracker;
		}
	}

	public List<ObjectStatus> GetEnemiesList () {
		return enemies;
	}
}
