using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CMControlFreeLook : MonoBehaviour
{

    public float panMultiple;

    void Start() {
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    public float GetAxisCustom(string axisName){
        if(axisName == "Mouse X"){
            if (Input.GetMouseButton(1)){
                return UnityEngine.Input.GetAxis("Mouse X") * panMultiple;
            } else{
                return 0;
            }
        }
        else if (axisName == "Mouse Y"){
            if (Input.GetMouseButton(1)){
                return UnityEngine.Input.GetAxis("Mouse Y") * panMultiple;
            } else{
                return 0;
            }
        }
        return UnityEngine.Input.GetAxis(axisName);
    }
}
