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
    public float jukeSpeed = 60f;

    public float runningTimestamp = 0f;
    private float walkingTimestamp = 0f;
    public bool running;

    [SerializeField]
    private TrackEnergy energy;
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

            CheckRun();
            if (running) {
                energy.DepleteStamina(1f);
            } else {
                energy.AddStamina(1f);
            }

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                float targetSpeed = running ? runningSpeed : walkingSpeed;

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                finalMove = moveDir * targetSpeed;
            } else {
                finalMove = Vector3.zero;
            }
        } else {
            finalMove = transform.forward*10f;
        }
    }

    void CheckRun() {
         if (running && (energy.curStamina <= 0 || !Input.GetKey(KeyCode.LeftShift))) {
            running = false;
            walkingTimestamp = Time.time;
            Debug.Log("end sprint");
        } else {
            if (!running && Input.GetKeyDown(KeyCode.LeftShift) && energy.curStamina >= 25) {
                runningTimestamp = Time.time;
                running = true;
                Debug.Log("start sprint");
            }
        }
    }

    void FixedUpdate() {
        rb.AddForce(finalMove);
    }
}