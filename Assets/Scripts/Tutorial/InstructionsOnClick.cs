using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRTK;

public class InstructionsOnClick : MonoBehaviour {

    public GameObject rightController;

    public GameObject tutorialEnemyControllerPrefab;
    private GameObject tutorialEnemyController;
    private GameObject enemyClone;

    private int _current;

    private bool _doInteractGrab = true;

    private Text _instruction;
  
    private string[] instructions = {
        "Look at the shop.",
        "The number at the top of the shop is the number of points you currently have.",
        "Points are gained by killing enemies, and can be used to buy weapon in the shop.",
        "Using the LEFT or RIGHT TOUCHPAD, teleport into the shop and approach the sword on the counter.",
        "Pick up the sword with the RIGHT TRIGGER BUTTON.",
        "Enemies will now spawn and attempt to breach the wall.\n\nDefend the flag - if the flag reaches the ground, then it's GAME OVER.",
        "To heal, press the LEFT TRIGGER BUTTON.", // if injured
        "Nice, you killed the enemy! You're ready to start the real game now.\n\nGood luck!" // once enemy dies
    };

    private Button _nextButton;

    #region Properties
    public int Current {
        get { return _current; }
        set { _current = value; }
    }

    public Text Instruction {
        get { return _instruction; }
        set { _instruction = value; }
    }

    public string[] Instructions {
        get { return instructions; }
        set { instructions = value; }
    }

    public Button NextButton {
        get { return _nextButton; }
        set { _nextButton = value; }
    }
    #endregion

    private void Start() {
        rightController.GetComponent<VRTK_InteractGrab>().ControllerGrabInteractableObject += new ObjectInteractEventHandler(DoInteractGrab);

        tutorialEnemyController = Instantiate(tutorialEnemyControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        tutorialEnemyController.GetComponent<TutorialEnemyController>().enabled = false;

        Current = 0;

        Instruction = GetComponentInChildren<Text>();
        Instruction.text = "OBJECTIVE:\n\nDefend the flag from incoming enemies";

        NextButton = GetComponentInChildren<Button>();
        NextButton.GetComponentInChildren<Text>().text = "NEXT";
    }

    private void DoInteractGrab(object sender, ObjectInteractEventArgs e) {
        if (e.target.name == "Sword (1)" && _doInteractGrab) {
            EnableInstructions(5);
            tutorialEnemyController.GetComponent<TutorialEnemyController>().enabled = true;
            _doInteractGrab = false;
        }
    }

    public void DisableInstructions() {
        gameObject.SetActive(false);
    }

    public void EnableInstructions(int instructionsIdx) {
        Instruction.text = instructions[instructionsIdx];
        gameObject.SetActive(true);
        Current = instructionsIdx;
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("Scene/Main_Menu");
    }

    public void OnClick() {
        Instruction.text = instructions[Current];

        if (Current == 0) {
            NextButton.GetComponentInChildren<Text>().text = "LOOK";
        }
        else if (Current == 1 || Current == 4 || Current == 6) {
            NextButton.GetComponentInChildren<Text>().text = "NEXT";
            DisableInstructions();
        }
        else if (Current == 7) {
            LoadMainMenu();
        }

        Current += 1;
    }

}
