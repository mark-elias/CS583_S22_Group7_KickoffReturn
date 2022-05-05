using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField]

    private Text myName;

    [SerializeField]

    private Text myColor;

    [SerializeField]
    private Text myDifficulty;



    void Start()
    {
        changeText();
    }

    public void changeText()
    {
        Debug.Log("changeText called");

        myName.text = PersistentManagerScript.Instance.PLAYER_NAME;

        myColor.text = PersistentManagerScript.Instance.PLAYER_COLOR;

        myDifficulty.text = PersistentManagerScript.Instance.DIFFICULTY;

    }

}
