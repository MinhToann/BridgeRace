using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{

    
    public bool isMoving;
    private bool isShowJoys = false;
    private void Update()
    {
        
    }
    
    public bool IsShowJoystick(bool isShowJoys)
    {
        this.isShowJoys = isShowJoys;
        return isShowJoys;
    }    
}
