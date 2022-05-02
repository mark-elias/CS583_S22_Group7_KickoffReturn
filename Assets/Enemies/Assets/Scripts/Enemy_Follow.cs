using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//changed
using UnityEngine.AI;


public class Enemy_Follow : MonoBehaviour

{

    // changed

    //public NavMeshAgent Enemy;

    //public NavMeshAgent enemy_kicker;

    // public NavMeshAgent enemy_slow;

    // public NavMeshAgent enemy_medium;

    // public NavMeshAgent enemy_fast;

    public NavMeshAgent enemy;
  

    public Transform Player;

    // changed

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        //Enemy.SetDestination(Player.position);


        //enemy_kicker.SetDestination(FPS_Controller.position);

        //enemy_slow.SetDestination(FPS_Controller.position);

        //enemy_medium.SetDestination(FPS_Controller.position);

        //enemy_fast.SetDestination(FPS_Controller.position);



        enemy.SetDestination(Player.position);
     


    }
}
