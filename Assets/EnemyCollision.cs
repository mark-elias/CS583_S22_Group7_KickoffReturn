using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    public bool playing = true;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" && playing)
        {
            Debug.Log("Tackled");
            FindObjectOfType<AudioManager>().Stop("Running");
            FindObjectOfType<AudioManager>().Play("Tackled");
            FindObjectOfType<AudioManager>().Play("CrowdAngry");
            SceneManager.LoadScene("GameOver");
        }
    }
}
