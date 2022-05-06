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
    private float speed = 25;
    private GameObject player;
    private bool caught = false;
    private AudioSource catchSFX;
    private Vector3 refVel = Vector3.zero;

    void Start() {
        transform.position = start.position;
        player = GameObject.FindWithTag("Player");
        catchSFX = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, end.position, speed*Time.deltaTime);
        if (!caught) {
            CheckCatch();
        }
    }

    void CheckCatch() {
        if (Vector3.Distance(transform.position, end.position) < 0.5f) {
            caught = true;
            catchSFX.Play();
        }
    }
}
