using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Bot : Character
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] Rigidbody rb;
    [SerializeField] SkinnedMeshRenderer[] skinMesh;
    private Vector3 destination;
    public bool isDestination => Vector3.Distance(TF.position, destination + (TF.position.y - destination.y) * Vector3.up) < 0.1f;
    public IState currentState;
    public bool isMoving = false;
    public Stage stage;

    public override void OnInit()
    {
        base.OnInit();
        ChangeState(new IdleState());
    }

    public override void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        for (int i = 0; i < skinMesh.Length; i++)
        {
            skinMesh[i].material = colorDataSO.GetMaterials(colorType);
        }
    }

    private void Update()
    {
        if(currentState != null)
        {
            currentState.OnExecute(this);
        }
        if(isEndgame)
        {
            ChangeState(new IdleState());
        }    
    }
    public void SetStage(Stage stage)
    {
        this.stage = stage;
    }
    public Stage GetStage()
    {
        return stage;
    }
   


    
    public void ChangeState(IState state)
    {
        if(currentState != null)
        {
            currentState.OnExit(this);
        }    
        currentState = state;
        Debug.Log("-----State--" + state);
        if(currentState != null)
        {
            currentState.OnEnter(this);
        }    
    }
    public void BotStopMove()
    {
        ChangeAnim(Const.IDLE_ANIM);       
    }    
    public void BotMoveToStair()
    {
        SetDestination(LevelManager.Instance.GetFinishPoint());  
    }    
    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        agent.SetDestination(destination);
        ChangeAnim(Const.RUN_ANIM);
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);   
        if (Cache.brickStair(other) != null)
        {
            if (Cache.brickStair(other).colorType != colorType)
            {              
                if (backs.Count > 0)
                {              
                    if (Vector3.Dot(transform.forward, Cache.brickStair(other).transform.forward) >= 0.5f)
                    {
                        Cache.brickStair(other).ChangeColor(colorType);
                        RemoveBrick();
                    }
                }
                else
                {
                    ChangeState(new FindBrickState());
                }
            }
        }

    }
}
