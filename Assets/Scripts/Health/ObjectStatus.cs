using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectStatus : MonoBehaviour {
    private ObjectHealth _health;

    private GameObject pointSystem;

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
    
    private void Die() {
        OnDied();
        if (gameObject.tag == "Player") {
            GameOver();
        } else {
            Debug.Log("DESTROYED???");
            Destroy(gameObject);
        }
        /*
        if (this.tag == "Enemy") {
            int pts = this.GetComponent<EnemyMovement>().GetPointVal();
            GameObject.Find("EnemyController").GetComponent<PointTracker>().AddPoints(pts);
            GameObject.Find("EnemyController").GetComponent<EnemyController>().GetEnemiesList().Remove(this.GetComponent<ObjectStatus>());
        }*/
    }

    private void GameOver() {
        SceneManager.LoadScene("Scene/GameOver");
    }

    private void OnDied() {
        if (Died != null) Died();
    }
}
