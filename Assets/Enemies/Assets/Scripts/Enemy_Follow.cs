using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//changed
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy_Follow : MonoBehaviour
{
    public NavMeshAgent enemy;
    private float speedDiff = 0.15f;
    private float diveCooldown = 1.5f;

    private GameObject player;
    private Rigidbody rb;
    private Rigidbody playerRB;
    private ThirdPersonCharacter character;

    private float diveTimer = 0f;
    private float distanceToGo;
    private float stoppingDis;
    private float tackleDis = 3f;
    private float tackleMultiplier = 2f;
    private float tackleDuration = 0.8f;

    public float awareDistance = 100f;

    private float proxDistance = 8f;

    private float normSpeed;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemy.updateRotation = false;
        stoppingDis = enemy.stoppingDistance;

        playerRB = player.GetComponent<Rigidbody>();

        normSpeed = character.m_MoveSpeedMultiplier;
        normSpeed = Random.Range(normSpeed-(speedDiff/2), normSpeed+(speedDiff/2));
        character.m_MoveSpeedMultiplier = normSpeed;
        
        Debug.Log(character.m_MoveSpeedMultiplier);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceToGo = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToGo < awareDistance) {
            if (distanceToGo < proxDistance) {
                enemy.SetDestination(player.transform.position);
            } else {
                enemy.SetDestination(player.transform.position + playerRB.velocity);
            }

            //distanceToGo = enemy.remainingDistance;
            if (distanceToGo < tackleDis && diveTimer + diveCooldown < Time.time) {
                diveTimer = Time.time;
                character.tryTackle();
            }

            EnemyMove();
        }
    }

    void EnemyMove() {
        if (diveTimer + tackleDuration < Time.time || diveTimer == 0f) {
            character.m_MoveSpeedMultiplier = normSpeed;

            character.Move(enemy.desiredVelocity, false, false);
        } else {
            character.m_MoveSpeedMultiplier = normSpeed*tackleMultiplier;
        }
    }
}
