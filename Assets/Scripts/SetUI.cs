using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUI : MonoBehaviour
{

    [SerializeField]
    private CharacterMove charMove;
    private TrackEnergy energy;
    [SerializeField]
    private Image runningSprite;
    [SerializeField]
    private Image neutralSprite;
    [SerializeField]
    private Image tiredSprite;

    // Start is called before the first frame update
    void Start()
    {
        energy = GetComponent<TrackEnergy>();
        runningSprite.enabled = false;
        tiredSprite.enabled = false;
        neutralSprite.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (charMove.running) {
            runningSprite.enabled = true;
            tiredSprite.enabled = false;
            neutralSprite.enabled = false;
        } else {
            if (energy.curStamina < energy.maxStamina) {
                tiredSprite.enabled = true;
                runningSprite.enabled = false;
                neutralSprite.enabled = false;
            } else {
                neutralSprite.enabled = true;
                runningSprite.enabled = false;
                tiredSprite.enabled = false;
            }
        }
    }
}
