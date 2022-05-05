using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTimer : MonoBehaviour
{
    public float endTime = 7f;
    public float startTime;

    void Start() {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > endTime) {
            SceneManager.LoadScene("Game");
        }
    }
}
