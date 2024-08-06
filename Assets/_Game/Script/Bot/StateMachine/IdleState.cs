using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    float timer;
    float randomTime;
    public void OnEnter(Bot bot)
    {
        timer = 0;
        randomTime = Random.Range(1f, 3f);
        bot.BotStopMove();
    }
    public void OnExecute(Bot bot)
    {
        if (LevelManager.Instance.isOnInit)
        {
            timer += Time.deltaTime;
        }
        
        if (timer > randomTime)
        {
            bot.ChangeState(new FindBrickState());
        }
        if(bot.isEndgame)
        {
            timer = 0f;
            randomTime = 0f;
            bot.ChangeState(null);
        }    
    }   
    public void OnExit(Bot bot)
    {

    }    
}
