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
    private ObjectHealth _health;

    private InstructionsOnClick instructions;

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
            Destroy(gameObject);
        }

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Main_Scene") {
            if (gameObject.tag == "Enemy") {
                int pts = this.GetComponent<EnemyMovement>().GetPointVal();
                print(pts);
                GameObject.Find("EnemyController").GetComponent<PointTracker>().AddPoints(1);
                GameObject.Find("EnemyController").GetComponent<EnemyController>().GetEnemiesList().Remove(this.GetComponent<ObjectStatus>());
            }
        }
        if (scene.name == "Tutorial") {
            instructions = GameObject.Find("UIFollower").transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<InstructionsOnClick>();

            instructions.NextButton.GetComponentInChildren<Text>().text = "MAIN MENU";
            instructions.EnableInstructions(7);
        }
    }

    private void GameOver() {
        SceneManager.LoadScene("Scene/GameOver");
    }

    private void OnDied() {
        if (Died != null) Died();
    }
}
