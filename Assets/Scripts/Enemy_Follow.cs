using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//changed
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

//---------------------------------------------
// edited by Marcos
//
using UnityEngine.SceneManagement;
//
//---------------------------------------------

public class Enemy_Follow : MonoBehaviour

{


    public NavMeshAgent enemy;

    public bool doesDive = false;
    public bool doesWaitTillCloseToFollow = false;
    public float distanceAwayUntilFollows = 25; 
    private GameObject player;
    public ThirdPersonCharacter character;
    public float diveCooldown = 5f;
    private float diveTimer = 0; 
    private float diveDistanceMultiplyier = 30;

    private float distanceToGo;
    private float stoppingDis;
    // changed

    // Start is called before the first frame update
    void Start()
    { 
        enemy = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemy.updateRotation = false;
        stoppingDis = enemy.stoppingDistance;
        diveTimer = Time.time; 
    }

    void checkMove()
    {

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (doesWaitTillCloseToFollow && dist < distanceAwayUntilFollows)
        {
            Debug.Log("Waiting");
            doesWaitTillCloseToFollow = false;
        }
        else if (!doesWaitTillCloseToFollow) //always "moving"
        {
            Movement();
        }
    }
    void Movement()
    {
        if (player != null && enemy != null)
            enemy.SetDestination(player.transform.position);
        else
            Debug.Log(this + " gameobject cannot find player or its navmesh");

        distanceToGo = enemy.remainingDistance;

        if (distanceToGo < stoppingDis) //to close to do anything
        {
            character.Move(Vector3.zero, false, false);
        }
        else if(doesDive && enemy.remainingDistance < enemy.stoppingDistance * diveDistanceMultiplyier
            && enemy.remainingDistance > enemy.stoppingDistance * diveDistanceMultiplyier - 1
            && enemy.remainingDistance != 0 && Time.time - diveTimer > diveCooldown)

        {
                Debug.Log("diev");
                character.tryTackle();
                diveTimer = Time.time;
                character.Move(Vector3.zero, false, false);
        }
        else if (distanceToGo > stoppingDis) //go hunt player
        {
            character.Move(enemy.desiredVelocity, false, false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        checkMove();
    }
    
     void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Tackled");
            character.Move(Vector3.zero, false, false);

            // ----------------------------------------------
            // Edited by Marcos
            // 
            // When the Player gets "tackled", the GameOver scene will load
            //
            SceneManager.LoadScene("GameOverScene");
            //
            // ----------------------------------------------------------------

            
        }
    }
}
