using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class FollowPath : MonoBehaviour
{
    [SerializeField]
    private Transform A;
    [SerializeField]
    private Transform B;

    private Vector3 movement;
    private Transform dest;
    private bool MoveToA = true;
    private float speed = 25;
    private ThirdPersonCharacter entity;

    void Start() {
        dest = A;
        entity = GetComponent<ThirdPersonCharacter>();
    }

    void FixedUpdate() {
        movement = dest.position - transform.position;
        entity.Move(movement, false, false);

        if (Vector3.Distance(transform.position, dest.position) < 2f) {
            if (MoveToA) {
                dest = B;
            } else {
                dest = A;
            }
            MoveToA = !MoveToA;
        }
    }
}