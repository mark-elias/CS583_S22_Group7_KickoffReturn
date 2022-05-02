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

    void Start() {
        mask = LayerMask.GetMask("Football");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.CheckSphere(kickPoint.position, kickRadius, mask) && !kickSFX.isPlaying) {
            Debug.Log("played kick");
            kickSFX.Play();
        }   
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.DrawWireSphere(kickPoint.position, kickRadius);
    }
}
