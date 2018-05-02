using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * @author Stephanie Xie, Sabrina Ko
 * 
 * Tracks the current status of the object this script is attached to.
 */
public class ObjectStatus : MonoBehaviour {

    public AudioClip crumblingSound;
    public AudioClip deathClip;

    public GameObject enemyDeathEffectPrefab;

    private ObjectHealth _health;

    private bool destroyObject;

    public delegate void DiedHandler();
    public event DiedHandler Died;

    public ObjectHealth Health {
        get { return _health; }
        set { _health = value; }
    }

    private void Awake() {
        Health = GetComponent<ObjectHealth>();
        Health.Died += Die;
    }

    private void Update() {
        if (destroyObject)
            Destroy(gameObject);
    }

    private void Die() {
        OnDied();

        if (gameObject.tag == "Player") {
            GameOver();
        } else {
            if (gameObject.tag == "Enemy") {
                EnemyDied();
            }
            if (gameObject.tag == "WallLow") {
                AudioSource.PlayClipAtPoint(crumblingSound, transform.position, 1f);
            }
            destroyObject = true;
        }
    }

    private void GameOver() {
        SceneManager.LoadScene("Scene/GameOver");
    }

    private void EnemyDied() {
        int pts = this.GetComponent<EnemyMovement>().GetPointVal();
        //print(pts);
        GameObject.Find("EnemyController").GetComponent<PointTracker>().AddPoints(1);
        GameObject.Find("EnemyController").GetComponent<EnemyController>().GetEnemiesList().Remove(this.GetComponent<ObjectStatus>());

        AudioSource.PlayClipAtPoint(deathClip, transform.position, 1f);
        PlayEnemyDeathEffect();
        destroyObject = true;
    }

    private void PlayEnemyDeathEffect() {
        GameObject enemyDeathEffect = Instantiate(enemyDeathEffectPrefab, transform.position, Quaternion.identity) as GameObject;

        // only want to play death effect once
        ParticleSystem ps = enemyDeathEffect.GetComponent<ParticleSystem>();
        Destroy(enemyDeathEffect, ps.duration - ps.startLifetime);
    }

    private void OnDied() {
        print("should be dead?");
        if (Died != null) Died();
    }
}
