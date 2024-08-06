using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    [SerializeField] protected string currentAnim;
    [SerializeField] private Animator animCha;
    public Renderer renderer;
    public ColorDataSO colorDataSO;
    public ColorType colorType;
    public bool isNextStage = false;

    [SerializeField] BackBrick brickCharacter;
    private BackBrick backBrick;
    [SerializeField] Transform modelCharacter;
    public List<BackBrick> backs = new List<BackBrick>();
    public bool isEndgame = false;
    int next = 0;
    private Transform tf;
    protected Transform TF
    {
        get
        {
            if (tf == null)
            {
                tf = transform;
            }
            return tf;
        }
    }
    protected void Start()
    {
        OnInit();
    }
    public virtual void OnInit()
    {
        ChangeAnim(Const.IDLE_ANIM);        
    }    
    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        renderer.material = colorDataSO.GetMaterials(colorType);
    }
    protected void ChangeAnim(string newAnim)
    {
        if(currentAnim != newAnim)
        {
            animCha.ResetTrigger(currentAnim);
            currentAnim = newAnim;
            animCha.SetTrigger(currentAnim);
        }
    }
    protected void AddBrick()
    {
        backBrick = Instantiate(brickCharacter, modelCharacter);             
        backBrick.colorBackBrick = colorType;
        backBrick.ChangeBackColor(backBrick.colorBackBrick);
        backs.Add(backBrick);
        for (int i = 1; i < backs.Count; i++)
        {
            Vector3 posY = backs[i - 1].transform.localPosition;
            posY.y += 0.15f;
            backs[i].transform.localPosition = posY;
        }

    }
    protected void RemoveBrick()
    {
        int index = backs.Count - 1;
        BackBrick b = backs[index];
        backs.RemoveAt(index);
        Destroy(b.gameObject);
    }
    public void ClearBrick()
    {
        for (int i = backs.Count - 1; i >= 0; i--)
        {
            Destroy(backs[i].gameObject);
        }
        backs.Clear();
    }

    public IEnumerator Spawn(Brick brick)
    {
       
        yield return new WaitForSeconds(2f);
        brick = SimplePool.Spawn<Brick>(PoolType.brick, brick.transform.position, brick.transform.rotation);
        brick.ChangeColor((ColorType)Random.Range(1, 7));
        
    }
    protected void StopTime()
    {
        Time.timeScale = 0;
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (Cache.brickGU(other) != null)
        {
            if (colorType == Cache.brickGU(other).colorType)
            {
                AddBrick();
                SimplePool.Despawn(Cache.brickGU(other));
                Cache.brickGU(other).ChangeColor(ColorType.None);
                StartCoroutine(Spawn(Cache.brickGU(other)));
            }
        }       
        if(other.CompareTag("FinishBox"))
        {
            ClearBrick();
           
            if(this is Player)
            {
                transform.position = LevelManager.Instance.GetFinishPoint();
                LevelManager.Instance.OnVictory();
                isEndgame = true;
            }
            else if (this is Bot)
            {
                LevelManager.Instance.OnLose();
                //transform.position = LevelManager.Instance.GetAllFinishPoints();
                transform.position = LevelManager.Instance.GetFinishPoint();
                Invoke(nameof(StopTime), 0.1f);
            }
            ChangeAnim(Const.IDLE_ANIM);
            LevelManager.Instance.isActive = false;
            LevelManager.Instance.isOnInit = false;
            
        }    
    }
}
