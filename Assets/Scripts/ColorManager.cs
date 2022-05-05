using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{

    [SerializeField] private Material myMaterial;
    public void OnTriggerChangeColor()
    {
        Debug.Log("OnTriggerChangeColor");
        if (PersistentManagerScript.Instance.PLAYER_COLOR == "BLUE")
            myMaterial.color = Color.blue;
        else if (PersistentManagerScript.Instance.PLAYER_COLOR == "GREEN")
            myMaterial.color = Color.green;
        else if (PersistentManagerScript.Instance.PLAYER_COLOR == "RED")
            myMaterial.color = Color.red;

    }
}
