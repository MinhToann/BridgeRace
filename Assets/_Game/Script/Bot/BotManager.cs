using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManager : Singleton<BotManager>
{
    public List<Bot> listBot = new List<Bot>();
    Bot bot;
    public void OnInit(List<Bot> listBots)
    {
        listBot = listBots;
        for (int i = 0; i < listBot.Count; i++)
        {
            bot = listBot[i];
            bot.ChangeColor((ColorType)(i + 2));
        }
    }
    public int GetCountListBot()
    {
        for(int i = 0; i < listBot.Count; i++)
        {
            return i;
        }
        return 0;
    }    
    public void OnDespawn()
    {
        for (int i = 0; i < listBot.Count; i++)
        {
            Destroy(listBot[i]);
        }
        listBot.Clear();
    }

    public void OnPlay()
    {

    }
}
