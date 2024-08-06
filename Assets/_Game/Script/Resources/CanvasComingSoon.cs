using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasComingSoon : UICanvas
{
    public void MainMenuButton()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.CloseUIDirectly<CanvasVictory>();
        UIManager.Instance.CloseUIDirectly<CanvasMenu>();
        LevelManager.Instance.ResetBrickPlayer();
        BotManager.Instance.OnDespawn();
        UIManager.Instance.OpenUI<CanvasMenu>();
        LevelManager.Instance.OnResetLevel();
        LevelManager.Instance.OnInit();
        LevelManager.Instance.isNext = true;
    }
}
