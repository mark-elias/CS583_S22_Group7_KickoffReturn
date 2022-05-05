using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endzone : MonoBehaviour
{
    private GameObject playerScore;

    private void Start()
    {
        playerScore = GameObject.Find("ScoringManager");
    }
    
    void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {

            Debug.Log("TouchDown");
            if (playerScore != null)
            {
                playerScore.GetComponent<Scoring>().touchDown();

            }
        }
    }
}
