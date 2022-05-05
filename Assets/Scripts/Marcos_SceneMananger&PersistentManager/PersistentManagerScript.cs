using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PersistentManagerScript : MonoBehaviour
{

    public static PersistentManagerScript Instance { get; private set; }

    //------------------------------------------------------------------------
    //
    // STATIC Variables
    // values that we want to keep throughout all scenes
    //
    //-------------------------------------------------------------------------
    
    public string PLAYER_NAME = "";

    public Color PLAYER_COLOR = Color.blue;

    public int LEVEL = 0;

    // --------------------------------


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

}
