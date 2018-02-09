using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject enemyPrefab;
    public GameObject bulletPrefab;

    public void SpawnEnemy() {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(10, 1, -10), Quaternion.identity);
    }

    private void Start() {
        SpawnEnemy();
    }
}
