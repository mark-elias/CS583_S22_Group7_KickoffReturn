
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    public Transform cam;
    private Animator animator;

    //----------------------------------------------
    // Edited by Marcos
    // I increased the Player speed to make the game easier
    // for some reason the walking speed controls the speed in game
    // and not the running speed
    //
    public float walkingSpeed = 10f;
    //----------------------------------------------------

    public float runningSpeed = 12f;

    public float timeToRunning = 3.0f;

    float runningTimer = 0f;


    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Start() {
        // Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        //-------------------------------------------------------------------
        // Edited by Marcos
        //
        // the Player speed changed depending on what DIFFICULTY
        // was chosen at the MainMenu
        //
        if (PersistentManagerScript.Instance.DIFFICULTY == "EASY")
        {
            walkingSpeed = 15;

            Debug.Log("DIFFICULTY set to EASY");
        }

        else if (PersistentManagerScript.Instance.DIFFICULTY == "MEDIUM")
        {
            walkingSpeed = 10;

            Debug.Log("DIFFICULTY set to MEDIUM");

        }

        else if (PersistentManagerScript.Instance.DIFFICULTY == "HARD")
        {
            walkingSpeed = 7;

            Debug.Log("DIFFICULTY set to HARD");

        }

        else
        {
            walkingSpeed = 10;
        }
        //
        //-----------------------------------------------------------------------------
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            bool running = Input.GetKey(KeyCode.LeftShift);
            if (running)
            {
                runningTimer += Time.deltaTime;
                //Debug.Log(runningTimer);
            }


            if (running && runningTimer > timeToRunning)
            {
                running = false;
                runningTimer = 0;
            }
            float targetSpeed = ((running) ? runningSpeed : walkingSpeed);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Vector3 finalMove = moveDir * targetSpeed * Time.deltaTime;

            if (finalMove.Equals(Vector3.zero)) {
                animator.SetBool("moving", false);
            } else {
                animator.SetBool("moving", true);
            }
            controller.Move(moveDir * targetSpeed * Time.deltaTime);
        } else {
            animator.SetBool("moving", false);
        }
    }
}

    