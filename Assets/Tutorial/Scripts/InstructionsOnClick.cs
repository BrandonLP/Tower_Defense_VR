using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRTK;

public class InstructionsOnClick : MonoBehaviour {

    private int _current;

    private Text _instruction;

    private string[] instructions = {
        "Look at the shop.\n\n(Press the TOUCHPAD to continue...)",
        "The number at the top of the shop is the number of points you currently have. Points are gained by killing enemies, and can be used to buy weapon in the shop.\n\n(Press the TOUCHPAD to continue...)",
        "Using the TOUCHPAD, teleport to the shop and pick up the sword with the RIGHT TRIGGER BUTTON.\n\n(Press the TOUCHPAD to continue...)",
        "An enemy will now spawn and attempt to breach the wall.\n\nDefend the flag - if the flag reaches the ground, then it's GAME OVER.\n\n(Press the TOUCHPAD to continue...)",
        "To heal, press the LEFT TRIGGER BUTTON.", // if injured
        "Nice, you killed the enemy! You're ready to start the real game now.\n\nGood luck!\n\n(Press BUTTON TWO to go back to the main menu.)" // once enemy dies
    };

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
    #endregion

    private void Start() {
        Current = -1;

        Instruction = GetComponentInChildren<Text>();
        Instruction.text = "OBJECTIVE:\n\nDefend the flag from incoming enemies.\n\n(Press the TOUCHPAD to continue...)";
    }

    public void DisableInstructions() {
        gameObject.SetActive(false);
    }

    public void EnableInstructions(int previousInstructionsIdx) {
        Current = previousInstructionsIdx;
        NextInstruction();
        gameObject.SetActive(true);
    }

    public void NextInstruction() {
        if (Current < instructions.Length - 1) {
            Instruction.text = instructions[Current + 1];
            Current += 1;
        }
    }
}
