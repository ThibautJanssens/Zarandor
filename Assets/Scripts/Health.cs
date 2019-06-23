using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {

    public int maxHealth;
    public List<ObjectBehaviour> dieBehaviours;

    public UnityEvent onDie;

    private int currentHealth;

    private void OnEnable() { //When object is instanciated
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            Die();
        }
    }

    private void Die(){
        onDie.Invoke();
        foreach(var item in dieBehaviours){
            item.Execute(gameObject);
        }
    }
}
