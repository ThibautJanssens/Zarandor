using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanonController : CanonController {

    private void OnDisable() {
        StopShooting();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonUp("Fire1") && !Input.GetButton("Fire1")) { //2e condition vérifie si 2 bouton fire1 enfoncé
            StopShooting();
        }
        if (Input.GetButtonDown("Fire1")) {
            StartShooting();
        }
    }
}
