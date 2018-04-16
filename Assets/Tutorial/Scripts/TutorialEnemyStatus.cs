using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyStatus : MonoBehaviour {
    private ObjectHealth _health;

    private InstructionsOnClick instructions;

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
        Destroy(gameObject);

        instructions = GameObject.Find("UIFollower").transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<InstructionsOnClick>();
        instructions.EnableInstructions(4);
    }
      
    private void OnDied() {
        if (Died != null) Died();
    }
}
