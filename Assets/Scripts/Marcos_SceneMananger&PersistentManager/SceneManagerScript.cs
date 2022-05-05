using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public Text update;
    public Image jersey;

    // --------------------------------------------------------------
    //
    // Main Menu scene selection
    //
    //----------------------------------------------------------------
    void Start() {
        if (jersey != null) {
            jersey.color = PersistentManagerScript.Instance.PLAYER_COLOR;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ProgressGame() {
        if (PersistentManagerScript.Instance.LEVEL < 10) {
            PersistentManagerScript.Instance.LEVEL++;
        }

        SceneManager.LoadScene("Game");
    }

    public void IntroGame() {
        if (VerifySettings()) {
            SceneManager.LoadScene("Kickoff");
        } else {
            ShowUpdate();
        }
    }

    public void CharacterSelect() {
        SceneManager.LoadScene("Character Selection");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }

    //------ Quit Application --------------------------------------
    public void Quit()
    {
        ResetSettings();
        Application.Quit();
    }

    //----------- Choosing Player Name ----------------------------
    //
    // when Player Name is entered 
    // store the NAME (string) into the Persistent Manager
    // and then change the Value in the Player Script
    //
    //-------------------------------------------------------------------
    public void SetName(string input)
    {
        PersistentManagerScript.Instance.PLAYER_NAME = input;
    }

    public void SetColor(int colorInput) {
        if (colorInput == 0) {
            PersistentManagerScript.Instance.PLAYER_COLOR = Color.blue;
        } else if (colorInput == 1) {
            PersistentManagerScript.Instance.PLAYER_COLOR = Color.green;
        } else {
            PersistentManagerScript.Instance.PLAYER_COLOR = Color.red;
        }

        if (jersey != null) {
            jersey.color = PersistentManagerScript.Instance.PLAYER_COLOR;
        }
    }

    public void SetLevel(int level) {
        PersistentManagerScript.Instance.LEVEL = level;
    }

    public bool VerifySettings() {
        if (PersistentManagerScript.Instance.PLAYER_NAME == "" ||
            PersistentManagerScript.Instance.LEVEL == 0) {
            return false;
        } else {
            return true;
        }
    }

    public void ResetSettings() {
        SetName("");
        SetColor(1);
        SetLevel(0);
    }

    public void ShowUpdate() {
        update.text = "Certain fields are missing!";

        update.transform.parent.gameObject.SetActive(false);
        update.transform.parent.gameObject.SetActive(true);
    }

    //------------------------------------------------------
    //
    // Changing scenes while playing game
    //
    //--------------------------------------------------------

    public void GoToMainMenuScene()
    {

        Debug.Log("Main Menu scene has been called");

        ResetSettings();
        SceneManager.LoadScene("Menu");

    }

    public void GoToGameOverScene()
    {
        Debug.Log("game over scene called");

        SceneManager.LoadScene("GameOver");

    }

    public void GoToWinningScene()
    {
        Debug.Log("WinningScene has been called");

        SceneManager.LoadScene("Win");
    }


}
