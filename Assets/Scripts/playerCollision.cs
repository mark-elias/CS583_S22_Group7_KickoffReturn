using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.name == "TR")
        {
            GameObject.Find("ScoringManager").GetComponent<Scoring>().touchDown();
        }
    }
}
