using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behaviours/ExplosionBehaviour")]
public class ExplosionBehaviour : ObjectBehaviour {
    [SerializeField]
    private GameObject explosionPrefab;

    public override void Execute(GameObject obj) {
        Poolable.Instantiate(explosionPrefab, obj.transform.position, Quaternion.identity);
    }
    
}
