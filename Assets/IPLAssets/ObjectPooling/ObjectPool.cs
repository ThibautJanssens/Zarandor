using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool {

    private Queue<GameObject> pool;
    private GameObject pooledPrefab;

    public ObjectPool(GameObject prefab){
        pool = new Queue<GameObject>();
        pooledPrefab = prefab;
    }

    public bool tryPool(GameObject obj){
        if(obj.name != pooledPrefab.name){ //simplification : on regarde s'il y a pas un objet du même nom
            return false;
        }
        pool.Enqueue(obj);
        return true;
    }

    public GameObject Unpool(){
        if(pool.Count > 0){
            return pool.Dequeue();
        }
        GameObject obj = Object.Instantiate(pooledPrefab);
        obj.name = pooledPrefab.name;
        return obj;
    }
}
