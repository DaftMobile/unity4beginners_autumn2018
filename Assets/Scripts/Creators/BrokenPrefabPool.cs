using UnityEngine;

public class BrokenPrefabPool : IPrefabPool
{
    private GameObject prefab;
    private int poolSize;

    public BrokenPrefabPool(GameObject prefab)
    {
        this.prefab = prefab;
        this.poolSize = poolSize;
    }

    public void Return(GameObject pooledObject)
    {
        Object.Destroy(pooledObject);
    }

    public GameObject Get()
    {
        return Object.Instantiate(prefab);
    }

    public bool IsEmpty()
    {
        return false;
    }
}