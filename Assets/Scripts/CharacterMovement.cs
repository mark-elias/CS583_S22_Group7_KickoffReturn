
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float walkingSpeed = 6f;
    public float runningSpeed = 12f;

    public float timeToRunning = 3.0f;

    float runningTimer = 0f;


    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        // new Vector3(transform.forward * horizontal, 0f, transform.right * vertical).normalized;

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
            controller.Move(moveDir * targetSpeed * Time.deltaTime);
            
        }

    }
}

    