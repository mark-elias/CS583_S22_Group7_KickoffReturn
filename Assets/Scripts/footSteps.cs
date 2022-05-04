using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footSteps : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {

        //play running audio
        FindObjectOfType<AudioManager>().Play("Running");
    }
}
