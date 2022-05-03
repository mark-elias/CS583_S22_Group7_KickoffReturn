using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody rb;
    public Transform cam;
    private Animator animator;
    private Vector3 finalMove;
    private CutsceneJump cutscene;

    public float walkingSpeed = 40f;
    public float runningSpeed = 100f;

    public float timeToRunning = 3.0f;

    float runningTimer = 0f;


    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Start() {
        // Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cutscene = GetComponent<CutsceneJump>();
    }

    void Update()
    {
        if (cutscene.control) {
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
                finalMove = moveDir * targetSpeed;
            } else {
                finalMove = Vector3.zero;
            }
        } else {
            finalMove = transform.forward*10f;
        }
    }

    void FixedUpdate() {
        rb.AddForce(finalMove);
    }
}
