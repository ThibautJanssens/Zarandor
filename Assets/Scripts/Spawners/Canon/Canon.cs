using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {

    public GameObject projectilePrefab;

    public void Fire(){
        GameObject projectile = Poolable.Instantiate(projectilePrefab, transform.position, transform.rotation);

        foreach(Transform item in projectile.GetComponentsInChildren<Transform>()){ //All bullet will have the layer
            item.gameObject.layer = gameObject.layer;
        }
    }

}
