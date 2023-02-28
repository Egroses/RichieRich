using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> objectPool;
    public int amountToPool;
    public GameObject spawnObject;
    void Start()
    {
        objectPool = new List<GameObject>();
        GameObject tmp;
        for (int i = objectPool.Count; i < amountToPool; i++)
        {
            tmp = Instantiate(spawnObject);
            tmp.SetActive(false);
            objectPool.Add(tmp);
        }
    }

    public void poolObject(int amount)
    {
        amountToPool += amount;
        GameObject tmp;
        for (int i = objectPool.Count; i < amountToPool; i++)
        {
            tmp = Instantiate(spawnObject);
            tmp.SetActive(false);
            objectPool.Add(tmp);
        }
    }

    public GameObject getPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                return objectPool[i];
            }
        }
        int yedek = amountToPool;
        poolObject(amountToPool);
        return objectPool[amountToPool-yedek];
    }
}
