using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cache
{
    private static Dictionary<Collider, Brick> dicGUBrick = new Dictionary<Collider, Brick>();
    private static Dictionary<Collider, StairBrick> dicStairBrick = new Dictionary<Collider, StairBrick>();
    public static Brick brickGU(Collider collider)
    {
        if(!dicGUBrick.ContainsKey(collider))
        {
            Brick brick = collider.GetComponent<Brick>();
            dicGUBrick.Add(collider, brick);
        }    
        return dicGUBrick[collider];
    }
    public static StairBrick brickStair(Collider collider)
    {
        if (!dicStairBrick.ContainsKey(collider))
        {
            StairBrick brick = collider.GetComponent<StairBrick>();
            dicStairBrick.Add(collider, brick);
        }
        return dicStairBrick[collider];
    }
}
