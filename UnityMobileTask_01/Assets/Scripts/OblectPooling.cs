using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private GameObject prefab; 
    private int poolSize = 20;

    public GameObject Prefab => prefab;

    private Queue<GameObject> pool;

    private void Awake()
    {
        pool = new Queue<GameObject>();
    }

    public void Initialize(GameObject bulletPrefab)
    {
        prefab = bulletPrefab;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);

            obj.SetActive(false);

            pool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        GameObject obj;

        if (pool.Count == 0)
        {
            obj = Instantiate(prefab);
        }
        else
        {
            obj = pool.Dequeue();
        }

        obj.SetActive(true);

        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}