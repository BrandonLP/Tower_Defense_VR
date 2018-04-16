using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public static SceneLoader Instance;

    private void Awake() {
        Instance = this;
    }

    public static void LoadGame() {
        SceneManager.LoadScene("Scene/Main_Scene");
    }

    public static void LoadGameOver() {
        SceneManager.LoadScene("Scene/GameOver");
    }

    public static void LoadMenu() {
        SceneManager.LoadScene("Scene/Main_Menu");
    }

    public static void LoadTutorial() {
        SceneManager.LoadScene("Scene/Tutorial");
    }


    //--- Wrapper methods ---//

    public void LoadGameWrapper() {
        LoadGame();
    }

    public void LoadGameOverWrapper() {
        LoadGameOver();
    }

    public void LoadMenuWrapper() {
        LoadMenu();
    }

    public void LoadTutorialWrapper() {
        LoadTutorial();
    }
}