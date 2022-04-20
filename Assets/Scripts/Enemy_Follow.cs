using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//changed
using UnityEngine.AI;


public class Enemy_Follow : MonoBehaviour

{

    // changed

    //public NavMeshAgent Enemy;

    public NavMeshAgent Enemy_Heavy;
    public NavMeshAgent Enemy_Medium;
    public NavMeshAgent Enemy_Light;


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

        Enemy_Heavy.SetDestination(Player.position);

        Enemy_Medium.SetDestination(Player.position);

        Enemy_Light.SetDestination(Player.position);
        
    }
}
