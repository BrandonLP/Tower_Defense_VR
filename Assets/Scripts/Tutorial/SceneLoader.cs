using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public static SceneLoader Instance;

    private void Awake() {
        Instance = this;
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene("Scene/" + sceneName);
    }
}