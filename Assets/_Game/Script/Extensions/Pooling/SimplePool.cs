using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePool
{
    private static Dictionary<PoolType, Pool> dicInstance = new Dictionary<PoolType, Pool>();

    public static void Preload(GameUnit prefab,int amout, Transform parent)
    {
        if(prefab == null)
        {
            Debug.Log("Preload Error !!!");
            return;
        }
        if(!dicInstance.ContainsKey(prefab.poolType) || dicInstance[prefab.poolType] == null)
        {
            Pool p = new Pool();
            p.Preload(prefab, parent);
            dicInstance[prefab.poolType] = p;
        }       
    }
    public static T Spawn<T>(PoolType poolType, Vector3 pos, Quaternion rot) where T : GameUnit
    {
        if(!dicInstance.ContainsKey(poolType))
        {
            Debug.Log("Spawn Error !!!");
        }
        return dicInstance[poolType].Spawn(pos, rot) as T;
    }
    public static void Despawn(GameUnit prefab)
    {
        if(!dicInstance.ContainsKey(prefab.poolType))
        {
            Debug.Log("Despawn Error !!!");
        }
        dicInstance[prefab.poolType].Despawn(prefab);
    }

    public static void DespawnAll()
    {
        foreach (var item in dicInstance)
        {
            item.Value.DespawnAll();
        }
    }
}
public class Pool
{
    private GameUnit prefab;
    private Transform parent;
    Queue<GameUnit> queueUnit = new Queue<GameUnit>();
    List<GameUnit> listUnit = new List<GameUnit>();
    public void Preload(GameUnit prefab, Transform parent)
    {
        this.prefab = prefab;
        this.parent = parent;
        for(int i = 0; i <  queueUnit.Count; i++)
        {
            Despawn(GameObject.Instantiate(prefab, parent));
        }
        
    }
    public GameUnit Spawn(Vector3 pos, Quaternion rot)
    {
        GameUnit unit;
        if(queueUnit.Count <= 0)
        {
            unit = GameObject.Instantiate(prefab, parent);
        }
        else
        {
            unit = queueUnit.Dequeue();
        }
        unit.TF.SetPositionAndRotation(pos, rot);
        listUnit.Add(unit);
        unit.gameObject.SetActive(true);
        return unit;
    }
    public void Despawn(GameUnit prefab)
    {
        if(prefab != null && prefab.gameObject.activeSelf)
        {
            prefab.gameObject.SetActive(false);
            listUnit.Remove(prefab);
            queueUnit.Enqueue(prefab);
        }
    }

    public void DespawnAll()
    {
        while (listUnit.Count > 0)
        {
            Despawn(listUnit[0]);
        }
    }
}
