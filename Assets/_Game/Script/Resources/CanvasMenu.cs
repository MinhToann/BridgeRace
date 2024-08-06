using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenu : UICanvas
{
    public void PlayButton()
    {
        UIManager.Instance.CloseAll();
        Time.timeScale = 1;
        LevelManager.Instance.isActive = true;
        LevelManager.Instance.isOnInit = true;
        UIManager.Instance.OpenUI<CanvasGamePlay>();
        UIManager.Instance.OpenUI<JoystickControl>();     
    }
    public void SettingButton()
    {
        UIManager.Instance.OpenUI<CanvasSetting>();
    }
}
