using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneJump : MonoBehaviour
{
    public bool control = false;

    private float duration = 2.7f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetTrigger("catch");
    }

    void Update() {
        if (!control && Time.time > duration) {
            control = true;
            this.enabled = false;
        }
    }
}
