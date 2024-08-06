using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] List<Level> gameLevels;
    [SerializeField] Player player;
    private Level levelGO;
    public int currentLevel = 0;
    [SerializeField] ColorDataSO colorDataSO;
    public bool isOnInit;
    public bool isActive;
    public bool isLose;
    public bool isNext;
    void Start()
    {
        GetLevel();
        OnInit();
    }
    public void GetLevel()
    {
        OnLoadLevel(currentLevel);
    }    
    public int SetCurrentLevel(int currentLevel)
    {
        this.currentLevel = currentLevel;
        return currentLevel;
    }    
   
    public void OnInit()
    {

        player.OnInit();
        SetPlayerTransform();
        ResetBrickPlayer();
        levelGO.OnInit();
        BotManager.Instance.OnInit(levelGO.listBots);
        //isOnInit = true;
        //isActive = true;
    }
    public void SetPlayerTransform()
    {
        player.transform.position = levelGO.startPoint.position;
    }    
    public void ResetBrickPlayer()
    {
        player.ClearBrick();
    }    
    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetFinishPoint()
    {
        return levelGO.endPoint.position;
    }
    public Vector3 GetAllFinishPoints()
    {
        int index = levelGO.listFinishPoints.Count - 1;
        Bot bot;
        for (int i = index; i >= 0; i--)
        {
            bot = levelGO.listBots[i];
            if (bot.backs.Count <= 0)
            {
                return levelGO.listFinishPoints[i].position;
            }         
        }
        return Vector3.zero;
    }
    public void OnDespawn()
    {
        //reset khi thua
        //Collect pool
        SimplePool.DespawnAll();
    }
    public void OnPlay()
    {

    }
    public int GetListLevelCount()
    {
        return gameLevels.Count;
    }
    public void OnReloadLevel()
    {
        OnDespawn();
        OnLoadLevel(currentLevel);
    }    
    public void OnNextLevel()
    {             
        if(currentLevel >= gameLevels.Count)
        {
            isNext = false;
        }
        else
        {
            OnDespawn();
            OnLoadLevel(++currentLevel);
        }
    }    
    public void OnResetLevel()
    {
        OnDespawn();
        OnLoadLevel(0);
        currentLevel = 0;
    }    
    private void OnLoadLevel(int level)
    {
        isOnInit = false;
        isActive = false;
        if (levelGO != null)
        {
            //destroy
            Destroy(levelGO.gameObject);
        }   
        if(level < gameLevels.Count) 
        {
            OnDespawn();
            levelGO = Instantiate(gameLevels[level]);
        }
       
    }
    public void OnComingSoon()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<CanvasComingSoon>();
    }
    public void OnVictory()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<CanvasVictory>();
        
    }

    public void OnLose()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<CanvasFail>();
    }

}
