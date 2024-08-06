using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishState : IState
{
    public void OnEnter(Bot bot)
    {

    }   
    public void OnExecute(Bot bot)
    {
        bot.ChangeState(new IdleState());
    }   
    public void OnExit(Bot bot)
    {

    }    
}
