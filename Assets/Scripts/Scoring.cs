using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------------
// Edited by Marcos
//
using UnityEngine.SceneManagement;
//----------------------------------------

public class Scoring : MonoBehaviour
{
    private GameObject startingPos;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = GameObject.Find("PlayerStarting");
        player = GameObject.FindGameObjectWithTag("Player");

        //Max start stadium audio
        FindObjectOfType<AudioManager>().Play("StadiumNoise");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(getScore());
    }
    public float getScore()
    {
        float score;
        if (startingPos != null && player != null)
        {
            float diff = player.transform.position.z - startingPos.transform.position.z;
           
            score = (diff >= 0 ? diff : 0);  
        }
        else
        {
            Debug.LogError("Cannot find player or starting position");
            score = -1f;
        }

        return score;
    }

    public void touchDown()
    {
    

        //--------------------------------------------
        // Edited by Marcos
        //
        SceneManager.LoadScene("WinningScene");
        //
        //----------------------------------------------
    }

}
