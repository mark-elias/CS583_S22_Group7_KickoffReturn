using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTimer : MonoBehaviour
{
    // public float endTime = 7f;

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Time.time);
        // if (Time.time > endTime)
        // {
        //     SceneManager.LoadScene("Main");
        // }
        Invoke("GoToPlayGameScene", 7f);
    }

    public void GoToPlayGameScene()
    {
        Debug.Log("GoToPlayScene called");

        // Load the Play Game scene

        SceneManager.LoadScene("Main");

    }
}
