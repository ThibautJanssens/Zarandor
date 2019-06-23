using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {
    [SerializeField]
    private float delay;

    private void OnEnable() {
        Invoke("DestroyObject", delay);
    }

    private void OnDisable() {
        CancelInvoke();    
    }

    void DestroyObject() {
        Poolable.Destroy(gameObject);
    }
}
