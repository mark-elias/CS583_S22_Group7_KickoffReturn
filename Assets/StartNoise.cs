using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNoise : MonoBehaviour
{
    void Start() {
        FindObjectOfType<AudioManager>().Play("StadiumNoise");
    }
}
