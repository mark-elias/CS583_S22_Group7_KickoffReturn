using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPath : MonoBehaviour
{
    [SerializeField]
    private Transform start;
    [SerializeField]
    private Transform end;

    private Rigidbody rb;
    private bool ended = false;
    private float speed = 25;
    private GameObject player;
    private bool caught = false;

    void Start() {
        transform.position = start.position;
        player = GameObject.FindWithTag("Player");

        // rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (!caught) {
            transform.position = Vector3.MoveTowards(transform.position, end.position, speed*Time.deltaTime);
        } else {
            transform.position = end.position;
        }
    }

    void CheckCatch() {
        if (Vector3.Distance(transform.position, end.position) < 0.5f) {
            caught = true;
        }
    }
}
