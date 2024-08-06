using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] private bool isDestroyOnClose = false;

    private void Awake()
    {
        RectTransform rect = GetComponent<RectTransform>();
        float ratio = (float)Screen.width / (float)Screen.height;
        if(ratio > 2.1f)
        {
            Vector2 leftBottom = rect.offsetMin;
            Vector2 rightTop = rect.offsetMax;

            leftBottom.y = 0f;
            rightTop.y = -100f;

            rect.offsetMin = leftBottom;
            rect.offsetMax = rightTop;
        }    
    }

    //Goi trc khi canvas active
    public virtual void Setup()
    {

    }
    //Goi sau khi canvas active
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }   
    
    //Tat canvas sau 1 khoang tgian
    public virtual void Close(float time)
    {
        Invoke(nameof(CloseDirectly), time);
    }  
    //Tat canvas truc tiep
    public virtual void CloseDirectly()
    {
        if(isDestroyOnClose)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }    
}
