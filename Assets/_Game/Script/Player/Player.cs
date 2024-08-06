using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    JoystickMovement joysMove;
    [SerializeField]  GameObject preventWall;
    private GameObject Wall;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private Rigidbody rb;
    public bool isMoving;
    private void Awake()
    {
        joysMove = GetComponent<JoystickMovement>();
    }

    public override void OnInit()
    {
        base.OnInit();
        rb.velocity = Vector3.zero;
        ChangeColor(ColorType.Pink);
    }
    public override void ChangeColor(ColorType colorType)
    {
        base.ChangeColor(colorType);
    }
    private void Update()
    {

    }
    void FixedUpdate()
    {
        if(LevelManager.Instance.isOnInit)
        {
            if (Input.GetMouseButton(0))
            {
                isMoving = true;
                rb.velocity = JoystickControl.direct * moveSpeed + rb.velocity.y * Vector3.up;
                rb.rotation = Quaternion.LookRotation(rb.velocity);
                ChangeAnim(Const.RUN_ANIM);
            }
            if (Input.GetMouseButtonUp(0))
            {
                rb.velocity = Vector3.zero;
                isMoving = false;
                ChangeAnim(Const.IDLE_ANIM);
            }
        }    
        
    }
    private void DestroyWall()
    {
        Destroy(Wall.gameObject);
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
                    if(Vector3.Dot(transform.forward, Cache.brickStair(other).transform.forward) >= 0.5f)
                    {
                        Cache.brickStair(other).ChangeColor(colorType);
                        RemoveBrick();
                    }                   
                }
                else
                {
                    if (Vector3.Dot(transform.forward, Cache.brickStair(other).transform.forward) >= 0.7f)
                    {
                        Wall = Instantiate(preventWall);
                        Wall.transform.position = Cache.brickStair(other).transform.position;
                        Wall.transform.rotation = Cache.brickStair(other).transform.rotation;
                        Invoke(nameof(DestroyWall), 1f);
                    }
                }
            }
        }
        if(other.CompareTag("DeadZone"))
        {
            LevelManager.Instance.OnLose();
            Invoke(nameof(StopTime), 0.1f);
        }    
    }
}
