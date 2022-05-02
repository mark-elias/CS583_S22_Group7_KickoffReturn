using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    // --------------------old code ---------
    //public Text output_rocketName;      // stored

    // public GameObject inputField;       // input

    // public GameObject textDisplay;      // output


    public Text Output_TestingValue;

    //---------------------------------------------------------------
    // Name
    //----------------------------------------------------------------

    public InputField Input_Name;
    public Text Output_Name;

    //---------------------------------------------------------------
    // Color
    //----------------------------------------------------------------

    public InputField Input_Color;
    public Text Output_Color;

    //---------------------------------------------------------------
    // Difficulty
    //----------------------------------------------------------------

    public InputField Input_Difficulty;
    public Text Output_Difficulty;


    // --------------------------------------------------------------
    //
    // START & UPDATE functions
    //
    //----------------------------------------------------------------
    private void Start()
    {
        // valueText.text = PersistentManagerScript.Instance.Value.ToString();

        //rocketName.text = PersistentManagerScript.Instance.rocketName.ToString();

        // SceneManager.LoadScene("Main Scene");

        //  textDisplay.GetComponent<Text>().text = PersistentManagerScript.Instance.rocketName.ToString();


        // displaying player health

        //displayHealth.GetComponent<Text>().text = PersistentManagerScript.Instance.playerHealth.ToString();


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

        //SceneManager.LoadScene("PlayGameScene");

    }

    public void GoToHowToPlayScene()
    {
        Debug.Log("How to Play scene called");

        //SceneManager.LoadScene("HowToPlayScene");

    }

    public void GoToCreditsScene()
    {
        Debug.Log("Credits scene called");

        //SceneManager.LoadScene("CreditsScene");

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

        Output_TestingValue.text = PersistentManagerScript.Instance.PLAYER_NAME;

        
    }

    //----------- Choosing Player Color ----------------------------
    //
    // when Player Color is selected 
    // store the COLOR (string) into the Persistent Manager
    // and then change the Value in the Player Script
    //
    //-------------------------------------------------------------------

    public void UserChoseBlue()
    {
        PersistentManagerScript.Instance.PLAYER_COLOR = "BLUE";
    }
    public void UserChoseGreen()
    {
        PersistentManagerScript.Instance.PLAYER_COLOR = "GREEN";
    }
    public void UserChoseRed()
    {
        PersistentManagerScript.Instance.PLAYER_COLOR = "RED";
    }

    //----------- Choosing Player Difficulty ----------------------------
    //
    // when difficulty is selected 
    // store the DIFFICULTY (string) into the Persistent Manager
    // and then change the Value in the Player Script
    //
    //-------------------------------------------------------------------
    public void UserChoseEasy()
    {
        PersistentManagerScript.Instance.DIFFICULTY = "EASY";
    }
    public void UserChoseMedium()
    {
        PersistentManagerScript.Instance.DIFFICULTY = "MEDIUM";
    }
    public void UserChoseHard()
    {
        PersistentManagerScript.Instance.DIFFICULTY = "HARD";
    }

    //------------------------------------------------------
    //
    // Changing scenes while playing game
    //
    //--------------------------------------------------------

    public void GoToMainMenuScene()
    {

        Debug.Log("Main Menu scene has been called");
        //SceneManager.LoadScene("Main Scene");

        // updating STATIC variable
        //PersistentManagerScript.Instance.Value++;

    }

    public void GoToGameOverScene()
    {
        Debug.Log("game over scene called");

        // SceneManager.LoadScene("Game Over");

    }


}
