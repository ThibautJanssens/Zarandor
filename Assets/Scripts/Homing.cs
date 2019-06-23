using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour {

    private Transform target;

    //Permet de déterminer quel "tag" les cibles des missiles doivent avoir
    public string targetTag;
    // Vitesse de rotation en degrés par seconde
    public int rotationSpeed;
    //permet de changer la direction du missile
    public Vector3 localForwardVector;

    private void Start() {
        if(GameObject.FindGameObjectWithTag(targetTag) != null)
            target = GameObject.FindWithTag(targetTag).transform;
    }

    private void Update() {
        if(target){
            RotateToTarget();
        }
    }

    void RotateToTarget(){
        //vecteur de direction vers la cible 
        Vector3 targetDirection = target.position - transform.position;
        //Vecteur directionnel dans le monde
        Vector3 currentWorldDirection = transform.TransformDirection(localForwardVector);
        //Angle de rotation vers la cible
        float angleToTarget = Vector3.Angle(currentWorldDirection, targetDirection);
        float rotationAngle = Mathf.Min(angleToTarget, rotationSpeed * Time.deltaTime);
        //axe de rotation qui doivent être perpendiculaire avec les deux autres vecteurs (utiliser produit vectoriel)
        Vector3 rotationAxis = Vector3.Cross(currentWorldDirection, targetDirection);
        Debug.DrawRay(transform.position, targetDirection, Color.blue);
        Debug.DrawRay(transform.position, currentWorldDirection, Color.yellow);
        Debug.DrawRay(transform.position, rotationAxis, Color.red);
        //Résoud le soucis quand les deux vecteur sont à exactement 180° (on inverse X ou Z)
        if(angleToTarget == 180f){
            rotationAxis = new Vector3(-currentWorldDirection.z, currentWorldDirection.y, currentWorldDirection.x);
        }
        rotationAxis.Normalize();
        transform.Rotate(rotationAxis, rotationAngle, Space.World);
    }
}
