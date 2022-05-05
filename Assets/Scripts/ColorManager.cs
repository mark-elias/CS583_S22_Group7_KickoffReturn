using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    
    void Start() {
        myMaterial.color = PersistentManagerScript.Instance.PLAYER_COLOR;
    }
}
