using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControl : UICanvas
{
    public static Vector3 direct;
    [SerializeField] RectTransform joystickBG;
    [SerializeField] RectTransform joystickControl;

    private Vector3 screen;
    private Vector3 MousePosition => Input.mousePosition - screen / 2;
    private Vector3 startPoint;
    private Vector3 updatePoint;
    public int magnitude;
    public GameObject joystickPanel;

    private void Awake()
    {
        screen.x = Screen.width;
        screen.y = Screen.height;
        direct = Vector3.zero;
        joystickPanel.SetActive(false);
    }
  
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && LevelManager.Instance.isActive)
        {
            startPoint = MousePosition;
            joystickBG.anchoredPosition = startPoint;
            joystickPanel.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            updatePoint = MousePosition;

            joystickControl.anchoredPosition = Vector3.ClampMagnitude((updatePoint - startPoint), magnitude) + startPoint;

            direct = (updatePoint - startPoint).normalized;
            direct.z = direct.y;
            direct.y = 0;

        }
        if(Input.GetMouseButtonUp(0))
        {
            joystickPanel.SetActive(false);
            direct = Vector3.zero;
        }    
    }

    private void OnDisable()
    {
        direct = Vector3.zero;
    }    
}
