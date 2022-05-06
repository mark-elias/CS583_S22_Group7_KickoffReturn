using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kicker : MonoBehaviour
{
    public float kickRadius;
    [SerializeField]
    private Transform kickPoint;
    [SerializeField]
    private AudioSource kickSFX;

    private LayerMask mask;
    private bool kicked = false;

    void Start() {
        mask = LayerMask.GetMask("Football");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Physics.CheckSphere(kickPoint.position, kickRadius, mask));
        if (Physics.CheckSphere(kickPoint.position, kickRadius, mask) && !kicked) {
            Debug.Log("played kick");
            kickSFX.Play();
            kicked = true;
        }   
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.DrawWireSphere(kickPoint.position, kickRadius);
    }
}
