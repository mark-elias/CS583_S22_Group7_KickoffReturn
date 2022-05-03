using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTimer : MonoBehaviour
{
    public float endTime = 7f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > endTime) {
            SceneManager.LoadScene("JonEditedScene");
        }
    }
}
