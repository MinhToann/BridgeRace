using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasVictory : UICanvas
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public void BestScore(int score)
    {
        scoreText.text = score.ToString();
    }    
    public void NextButton()
    {
        
        if(!LevelManager.Instance.isNext)
        {
            LevelManager.Instance.OnComingSoon();
        }
        else
        {
            UIManager.Instance.CloseAll();
            LevelManager.Instance.OnNextLevel();
            LevelManager.Instance.OnInit();
            UIManager.Instance.OpenUI<CanvasMenu>();
        }
    }    
    public void MainMenuButton()
    {
        Close(0);
        LevelManager.Instance.ResetBrickPlayer();
        BotManager.Instance.OnDespawn();
        UIManager.Instance.OpenUI<CanvasMenu>();
        LevelManager.Instance.OnReloadLevel();
        LevelManager.Instance.OnInit();
    }
}
