using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int score = 0;
    void Start()
    {
        UIManager.Instance.OpenUI<CanvasMenu>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && UIManager.Instance.IsOpened<CanvasGamePlay>())
        {
            UIManager.Instance.GetUI<CanvasGamePlay>().UpdateCoin(++score);
        }    
        if(Input.GetKeyUp(KeyCode.V))
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<CanvasVictory>().BestScore(score);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<CanvasFail>().BestScore(score);
        }
    }
}
