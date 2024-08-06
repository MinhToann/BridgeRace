using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] List<Brick> listBricks = new List<Brick>();
    [SerializeField] Transform Floor;
    internal void OnInit()
    {
        SpawnBricks();
    }
      
    public bool CheckColorBrick(ColorType colorType)
    {
        for(int i = 0; i < listBricks.Count;i++)
        {
            if (listBricks[i].colorType == colorType)
            {
                return true;
            }
        }
        return false;
    }
    public Vector3 GetBrickOnStage(ColorType colorType)
    {
        for (int i = 0; i < listBricks.Count; i++)
        {
           if (listBricks[i].colorType == colorType)
           {
                return listBricks[i].transform.position;
           }
        }
        return Vector3.zero;
    }

    public void SpawnBricks()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Brick bricks = SimplePool.Spawn<Brick>(PoolType.brick, transform.position, transform.rotation);
                bricks.ChangeColor((ColorType)Random.Range(1, 7));
                bricks.transform.position = new Vector3(transform.position.x + i - 5.5f, Floor.position.y + 0.7f, transform.position.z + j - 4f);
                listBricks.Add(bricks);
                
            }
        }
    }


    
}
