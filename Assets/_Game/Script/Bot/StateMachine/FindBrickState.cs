using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class FindBrickState : IState
{
    float randomNum;
    public void OnEnter(Bot bot)
    {
        randomNum = Random.Range(12,13);
        if (bot.GetStage().CheckColorBrick(bot.colorType))
        {
            Vector3 des;
            des = bot.GetStage().GetBrickOnStage(bot.colorType);
            bot.SetDestination(des);
        }
    }
    public void OnExecute(Bot bot)
    {      
        if(bot.backs.Count >= randomNum)
        {
            bot.ChangeState(new BuildState());
        }
        else
        {
            if(bot.GetStage().CheckColorBrick(bot.colorType))
            {
                if(bot.isDestination)
                {
                    Vector3 des;
                    des = bot.GetStage().GetBrickOnStage(bot.colorType);
                    bot.SetDestination(des);                      
                }              
            }
            else
            {
                bot.ChangeState(new IdleState());               
            }
        }
        if(bot.isEndgame)
        {
            bot.BotStopMove();
            //Vector3 des;
            //des = LevelManager.Instance.GetAllFinishPoints();
            //bot.SetDestination(des);
            //if (bot.isDestination)
            //{
            //    bot.ChangeState(new IdleState());
            //}
        }

    }
    public void OnExit(Bot bot)
    {
        
    }
}
