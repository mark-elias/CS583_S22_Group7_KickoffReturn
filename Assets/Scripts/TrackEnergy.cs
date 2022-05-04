using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackEnergy : MonoBehaviour
{
    public Image energyBar;

    private Vector3 startScale;
    private float curScale;
    private float multiple;
    public float maxStamina = 100;
    public float curStamina;

    private float depletionRate = 0.4f;
    private float regenRate = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        startScale = energyBar.transform.localScale;
        curStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        multiple = curStamina/maxStamina;
        energyBar.transform.localScale = new Vector3(multiple*startScale.x, startScale.y, startScale.z);
    }

    public void AddStamina(float input) {
        if (curStamina < maxStamina) {
            curStamina += input * regenRate;
        }
    }

    public void DepleteStamina(float input) {
        if (curStamina > 0) {
            curStamina -= input * depletionRate;
        }
    }
}
