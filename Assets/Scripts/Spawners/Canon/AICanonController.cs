using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICanonController : CanonController {

    public float minDelayBeforeShooting;
    public float maxDelayBeforeShooting;

    private void OnEnable() {
        Invoke("StartShooting", Random.Range(minDelayBeforeShooting, maxDelayBeforeShooting));
    }

    private void OnDisable() {
        CancelInvoke();
        StopShooting();
    }
}
