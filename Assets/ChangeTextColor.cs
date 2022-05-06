using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextColor : MonoBehaviour
{
    [SerializeField]
    private Text colorText;
    private Text ownText;

    void Start() {
        ownText = GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        if (colorText.text == "GREEN") {
            ownText.color = Color.green;
        } else if (colorText.text == "BLUE") {
            ownText.color = Color.blue;
        } else {
            ownText.color = Color.red;
        }
    }
}
