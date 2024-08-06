using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildState : IState
{

    public void OnEnter(Bot bot)
    {
   
    }
    public void OnExecute(Bot bot)
    {
        if (bot.backs.Count > 0)
        {
            bot.BotMoveToStair();
        }
        else
        {
            bot.ChangeState(new FindBrickState());
            if(bot.isEndgame)
            {
                bot.BotStopMove();
            }   
        }
    }
    public void OnExit(Bot bot)
    {

    }
}
