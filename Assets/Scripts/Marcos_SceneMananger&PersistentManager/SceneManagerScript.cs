using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public Text Output_Testing_NAME;
    public Text Output_Testing_COLOR;
    public Text Output_Testing_DIFFICULTY;


    //---------------------------------------------------------------
    // Name
    //----------------------------------------------------------------

    public InputField Input_Name;
    public Text Output_Name;

    //---------------------------------------------------------------
    // Color
    //----------------------------------------------------------------

    public Dropdown Input_Color;
    public Text Output_Color;

    //---------------------------------------------------------------
    // Difficulty
    //----------------------------------------------------------------

    public Dropdown Input_Difficulty;
    public Text Output_Difficulty;


    // --------------------------------------------------------------
    //
    // START & UPDATE functions
    //
    //----------------------------------------------------------------
    private void Start()
    {

        // displays STATIC values: NAME, COLOR, and DIFFICULTY to the PlayGameScene
        // when that scene is loaded

        if (Output_Testing_NAME!=null)
            Output_Testing_NAME.text = PersistentManagerScript.Instance.PLAYER_NAME;

        if (Output_Testing_COLOR != null)
            Output_Testing_COLOR.text = PersistentManagerScript.Instance.PLAYER_COLOR;

        if (Output_Testing_DIFFICULTY != null)
            Output_Testing_DIFFICULTY.text = PersistentManagerScript.Instance.DIFFICULTY;

    }
    
    private void Update()
    {

    }

    // --------------------------------------------------------------
    //
    // Main Menu scene selection
    //
    //----------------------------------------------------------------

    public void GoToPlayGameScene()
    {
        Debug.Log("GoToPlayScene called");

        // Load the Play Game scene
        SceneManager.LoadScene("PlayerRunField");

    }

    public void GoToHowToPlayScene()
    {
        Debug.Log("How to Play scene called");

        SceneManager.LoadScene("HowToPlayScene");

    }

    public void GoToCreditsScene()
    {
        Debug.Log("Credits scene called");

        SceneManager.LoadScene("CreditsScene");

    }

    //------ Quit Application --------------------------------------
    public void QuitApplication()
    {
        Debug.Log("Quit Application called");
        Application.Quit();
    }

    //----------- Choosing Player Name ----------------------------
    //
    // when Player Name is entered 
    // store the NAME (string) into the Persistent Manager
    // and then change the Value in the Player Script
    //
    //-------------------------------------------------------------------
    public void UserEnteredName()
    {
        Debug.Log("Player has entered their name");

        // Display Name to screen
        Output_Name.text = Input_Name.text;

        // Save Name to Persistent Manager
        // use .text and NOT toString()
        PersistentManagerScript.Instance.PLAYER_NAME = Input_Name.text;

        Output_Testing_NAME.text = PersistentManagerScript.Instance.PLAYER_NAME;


    }

    //----------- Choosing Player Color ----------------------------
    //
    // when Player Color is selected 
    // store the COLOR (string) into the Persistent Manager
    // and then change the Value in the Player Script
    //
    //-------------------------------------------------------------------

    public void SelectPlayerColor()
    {
        // Drop Down menu outputs INTEGER values
        // convert a STRING to TEXT by using .text

        if (Input_Color.value == 0)
        {
            Output_Color.text = "BLUE";

            PersistentManagerScript.Instance.PLAYER_COLOR = "BLUE";

            Output_Testing_COLOR.text = PersistentManagerScript.Instance.PLAYER_COLOR;

        }

        else if (Input_Color.value == 1)
        {
            Output_Color.text = "GREEN";

            PersistentManagerScript.Instance.PLAYER_COLOR = "GREEN";

            Output_Testing_COLOR.text = PersistentManagerScript.Instance.PLAYER_COLOR;
        }

        else if (Input_Color.value == 2)
        {
            Output_Color.text = "RED";

            PersistentManagerScript.Instance.PLAYER_COLOR = "RED";

            Output_Testing_COLOR.text = PersistentManagerScript.Instance.PLAYER_COLOR;
        }

        else
        {
            Output_Color.text = "Choose a Player Color";
        }

    }

    //----------- Choosing Player Difficulty ----------------------------
    //
    // when difficulty is selected 
    // store the DIFFICULTY (string) into the Persistent Manager
    // and then change the Value in the Player Script
    //
    //-------------------------------------------------------------------

    public void SelectDifficulty()
    {
        // Drop Down menu outputs INTEGER values
        // convert a STRING to TEXT by using .text

        if (Input_Difficulty.value == 0)
        {
            Output_Difficulty.text = "EASY";

            PersistentManagerScript.Instance.DIFFICULTY = "EASY";

            Output_Testing_DIFFICULTY.text = PersistentManagerScript.Instance.DIFFICULTY;
        }

        else if (Input_Difficulty.value == 1)
        {
            Output_Difficulty.text = "MEDIUM";

            PersistentManagerScript.Instance.DIFFICULTY = "MEDIUM";

            Output_Testing_DIFFICULTY.text = PersistentManagerScript.Instance.DIFFICULTY;
        }

        else if (Input_Difficulty.value == 2)
        {
            Output_Difficulty.text = "HARD";

            PersistentManagerScript.Instance.DIFFICULTY = "HARD";

            Output_Testing_DIFFICULTY.text = PersistentManagerScript.Instance.DIFFICULTY;
        }

        else
        {
            Output_Color.text = "Choose a Game Difficulty";
        }

    }

    //------------------------------------------------------
    //
    // Changing scenes while playing game
    //
    //--------------------------------------------------------

    public void GoToMainMenuScene()
    {

        Debug.Log("Main Menu scene has been called");

        SceneManager.LoadScene("MainMenuScene");

        // updating STATIC variable
        //PersistentManagerScript.Instance.Value++;

    }

    public void GoToGameOverScene()
    {
        Debug.Log("game over scene called");

        SceneManager.LoadScene("GameOverScene");

    }

    public void GoToWinningScene()
    {
        Debug.Log("WinningScene has been called");

        SceneManager.LoadScene("WinningScene");
    }


}
