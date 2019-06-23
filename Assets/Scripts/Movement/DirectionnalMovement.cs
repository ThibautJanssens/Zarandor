using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionnalMovement : MonoBehaviour {

    public int speed;
    public Vector3 direction; //on peut aussi utiliser un vector2
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction.normalized * speed * Time.deltaTime); //Si pas normalized, au plus long le vecteur est, au plus rapide il sera
	}
}
