using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanvasSetting : UICanvas
{
    [SerializeField] private GameObject[] buttons;
    public void SetState(UICanvas canvas)
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }    
        if(canvas is CanvasGamePlay)
        {           
            buttons[0].gameObject.SetActive(true);
            buttons[1].gameObject.SetActive(true);
        }   
        else if(canvas is CanvasMenu)
        {
            buttons[2].gameObject.SetActive(true);
        }    
    }    
    public void MainMenuButton()
    {
        UIManager.Instance.CloseAll();   
        UIManager.Instance.OpenUI<CanvasMenu>();
        LevelManager.Instance.OnReloadLevel();
        LevelManager.Instance.OnInit();
        //LevelManager.Instance.SetPlayerTransform();
        //LevelManager.Instance.ResetBrickPlayer();
        //BotManager.Instance.OnDespawn();
    }    
}
