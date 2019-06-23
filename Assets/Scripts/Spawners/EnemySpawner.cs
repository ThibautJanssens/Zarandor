using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float spawnIntervalMin;
    public float spawnIntervalMax;
    public Vector2 spawnLine;

    public LayerMask dontSpawnNearLayers;
    public float spawnRadius;

    private int maxSpawnAttempts = 10;

    private void OnEnable() {
        StartCoroutine(EnemySpawnerCoroutine());
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    private void Spawn(){
        Vector3 pos = GetRandomPositionInZone();
        Poolable.Instantiate(enemyPrefab, pos, transform.rotation);
    }

    private IEnumerator EnemySpawnerCoroutine(){
        while(true){
            Spawn();
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));
        }
    }

    private Vector3 GetRandomPositionInZone() {

        Vector3 pos = Vector3.zero;

        for (int i = 0; i < maxSpawnAttempts; i++){

            pos = Random.insideUnitCircle;

            pos.Scale(spawnLine);
            pos += transform.position;
            if(IsValidPosition(pos)){
                return pos;
            }
        }
        return Vector3.zero;
    }

    private bool IsValidPosition(Vector3 pos){
        return !Physics2D.OverlapCircle(pos, spawnRadius, dontSpawnNearLayers.value);
    }
}
