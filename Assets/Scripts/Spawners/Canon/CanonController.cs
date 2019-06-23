using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour {

    public Canon canon;
    public float fireInterval;

    private bool isShooting = false;
    private Coroutine fireCR;

    public void StartShooting(){
        if (!isShooting) {
            isShooting = true;
            fireCR = StartCoroutine(FireCoroutine());
        }
    }

    public void StopShooting(){
        isShooting = false;
        if(fireCR != null){
            StopCoroutine(fireCR);
        }
    }

    private IEnumerator FireCoroutine(){
        while(isShooting == true){
            canon.Fire();
            yield return new WaitForSeconds(fireInterval);
        }
    }
}
