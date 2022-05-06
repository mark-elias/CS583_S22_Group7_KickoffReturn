using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchDown : MonoBehaviour
{
    private GameObject playerScore;

    private void Start()
    {
        playerScore = GameObject.Find("ScoringManager");
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.transform.tag == "Player")
        {
           
            if (playerScore != null)
            {
                playerScore.GetComponent<Scoring>().touchDown();
            }
        }
    }
}
