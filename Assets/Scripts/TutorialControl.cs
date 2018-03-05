using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class TutorialControl : MonoBehaviour {
    private void Start() {
        GetComponent<VRTK_ControllerEvents>().ButtonTwoPressed += new ControllerInteractionEventHandler(DoButtonTwoPressed);
    }

    private void DoButtonTwoPressed(object sender, ControllerInteractionEventArgs e) {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Tutorial") {
            SceneManager.LoadScene("Main_Scene");
        }
    }
}
