using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIControlle : MonoBehaviour
{
    private Text t_playerScore;

    private Scoring scoreManager; 
    // Start is called before the first frame update
    void Start()
    {
        t_playerScore = GameObject.Find("T_PlayerScoring").GetComponent<Text>();
        scoreManager = GameObject.Find("ScoringManager").GetComponent<Scoring>();
    }

    // Update is called once per frame
    void Update()
    {
        if (t_playerScore != null & scoreManager != null)
            t_playerScore.text = "Score: " + ( (int) scoreManager.getScore()).ToString();
    }
}
