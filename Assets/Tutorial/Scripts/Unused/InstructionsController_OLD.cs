using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsControllerOLD : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    public GameObject swordSnapDropZone;

    public float delayTime = 3.0f;

    private ObjectHealth enemyHealth;

    private InstructionsOnClickOLD instructions;

    private ObjectHealth playerHealth;

    private GameObject pointSystem;

    private float secsLeft;

    public delegate void DiedHandler();
    public event DiedHandler Died;

    private void Start() {
        instructions = transform.GetChild(0).gameObject.GetComponent<InstructionsOnClickOLD>();

        playerHealth = player.GetComponent<ObjectHealth>();

        StartCoroutine(InShopAlert());
        StartCoroutine(NeedHealingAlert());
    }
        
    public bool NearSwordSnapDropZone() {
        // return true if player is within a radius of 64 units to the sword snap drop zone
        return ((swordSnapDropZone.transform.position - player.transform.position).sqrMagnitude < (8*8));
    }

    IEnumerator InShopAlert() {
        while (true) {
            while (!(instructions.Current == 5 && NearSwordSnapDropZone())) {
                yield return null;
            }

            yield return new WaitForSeconds(1.5f);
            instructions.EnableInstructions(4);

            yield break;
        }
    }

    IEnumerator NeedHealingAlert() {
        while (true) {
            while (!playerHealth.AtFullHealth()) {
                yield return null;
            }

            while (playerHealth.AtFullHealth()) {
                yield return null;
            }

            instructions.EnableInstructions(6);

            yield break;
        }
    }
}
