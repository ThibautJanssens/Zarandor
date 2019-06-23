using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDestroy : MonoBehaviour {

    public bool destroySelf = false;
    public bool destroyOther = false;

    private void OnTriggerEnter2D(Collider2D col) {
        Rigidbody2D rb = col.attachedRigidbody;
        GameObject obj = rb ? rb.gameObject : col.gameObject;

        if(destroyOther){
            Poolable.Destroy(obj);
        }
        if(destroySelf){
            Poolable.Destroy(gameObject);
        }
    }
}
