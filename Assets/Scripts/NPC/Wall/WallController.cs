using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Stephanie Xie
 * 
 * Updates the wall's appearance after getting damaged.
 */
public class WallController : MonoBehaviour {

    public float maxHealth;

    public GameObject wallPartMedium;  // appearance of wall part at 2/3 health
    public GameObject wallPartLow;  // appearance of wall part at 1/3 health

    private ObjectHealth _wallPartHealth;

    private Vector3 _wallPartPosition;
    private Quaternion _wallPartRotation;

    public AudioClip crumblingSound;
    //private AudioSource audioSource;

    #region Properties
    public ObjectHealth WallPartHealth {
        get { return _wallPartHealth; }
        set { _wallPartHealth = value; }
    }

    public Vector3 WallPartPosition {
        get { return _wallPartPosition; }
        set { _wallPartPosition = value; }
    }

    public Quaternion WallPartRotation {
        get { return _wallPartRotation; }
        set { _wallPartRotation = value; }
    }
    #endregion

    private void Awake() {
        WallPartHealth = GetComponent<ObjectHealth>();
        WallPartHealth.MaxHealth = maxHealth;

        //audioSource = GetComponent<AudioSource>();
    }

    /*
    private void OnMouseDown() {
        if (gameObject.tag.Contains("Wall")) {
            WallPartPosition = transform.position;
            WallPartRotation = transform.rotation;

            WallPartHealth.Damage(10);
            //print("max = " + WallPartHealth.MaxHealth);
            //print("current = " + WallPartHealth.CurrentHealth);
            //print("---------------");
            CheckState();
        }
    }
    */

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy") {
            float amountDamagedBy = collision.gameObject.GetComponent<EnemyAttack>().BaseDamage;

            WallPartPosition = transform.position;
            WallPartRotation = transform.rotation;

            WallPartHealth.Damage(amountDamagedBy);
            //print("max = " + WallPartHealth.MaxHealth);
            //print("current = " + WallPartHealth.CurrentHealth);
            //print("---------------");
            CheckState();
        }
    }

    public void CheckState() {
        if (gameObject.tag == "WallHigh" && WallPartHealth.CurrentHealth <= maxHealth / 3 * 2)
            ChangeAppearance(wallPartMedium);

        if (gameObject.tag == "WallMedium" && WallPartHealth.CurrentHealth <= maxHealth / 3)
            ChangeAppearance(wallPartLow);
    }

    // Change appearance of wall part
    public void ChangeAppearance(GameObject newState) {
        AudioSource.PlayClipAtPoint(crumblingSound, transform.position, 1f);
        Destroy(gameObject);
        Instantiate(newState, WallPartPosition, WallPartRotation);
    }

}
