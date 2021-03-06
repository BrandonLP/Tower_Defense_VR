using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagBehavior : MonoBehaviour {

    private AudioSource audioSource;

    public GameObject flagPole;

    private Vector3 _currentPosition;

    private float _flagSpeed = 0.05f;

    private Vector3 _startPosition;

    public Vector3 CurrentPosition {
        get { return _currentPosition; }
        set { _currentPosition = value; }
    }

    public float FlagSpeed {
        get { return _flagSpeed; }
        set { _flagSpeed = value; }
    }

    public Vector3 StartPosition {
        get { return _startPosition; }
        set { _startPosition = value; }
    }

    private void Start() {
        StartPosition = transform.localPosition;
        CurrentPosition = StartPosition;

        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    private void Update () {
        bool enemyTouchingFlagPole = flagPole.GetComponent<FlagPoleBehavior>().EnemyTouchingFlagPole;

        if (enemyTouchingFlagPole) {
            if (transform.localPosition.y < 0.001f) {
                GameOver();
            }
            LowerFlag();
        } else {
            RaiseFlag();
        }
    }

    public void GameOver() {
        SceneManager.LoadScene("Scene/GameOver");
    }

    public void LowerFlag() {
        audioSource.Play();

        transform.localPosition = Vector3.MoveTowards(
            transform.localPosition, 
            new Vector3(transform.localPosition.x, 0, transform.localPosition.z), 
            Time.deltaTime * FlagSpeed
        );  
    }

    public void RaiseFlag() {
        audioSource.Stop();

        transform.localPosition = Vector3.MoveTowards(
            transform.localPosition, 
            new Vector3(transform.localPosition.x, StartPosition.y, transform.localPosition.z), 
            Time.deltaTime * FlagSpeed
        ); 
    }

}

