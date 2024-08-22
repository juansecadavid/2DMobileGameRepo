using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;
    [SerializeField] int poolSize = 10;
    private List<GameObject> pool;
    void Start()
    {
        pool = new List<GameObject>();
        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    private GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }

    public void SpawnObject(Vector3 position)
    {
        GameObject obj = GetPooledObject();
        if (obj != null)
        {
            obj.transform.position = position;
            obj.SetActive(true);
        }
    }
}
