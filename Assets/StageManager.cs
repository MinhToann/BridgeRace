using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    //public List<Stage> stage;
    //[SerializeField] Brick stageBrick;
    //public int currentStage = 0;
    //void Start()
    //{
    //    OnInit();
    //}

    private void OnInit()
    {
       // SpawnBrickOnStage(currentStage);
        //stageBrick.SpawnBricks(stage[currentStage].transform);
        //Debug.Log("stage count " + stage.Count);
    }
    //void Update()
    //{
    //    if(Character.Instance.isNextStage)
    //    {
    //        ++currentStage;
    //        SpawnBrickOnStage(currentStage);
    //    }    
    //}
    //private void SpawnBrickOnStage(int index)
    //{
    //    if (index < stage.Count)
    //    {
    //        stg = stage[index];
    //        stageBrick.SpawnBricks(stg);
    //    }
    //    Debug.Log("index " + index);
    //}

}
