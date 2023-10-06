using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //This script is meant to be inserted on the Player object, connect this to the EndGameFunction script!!

    [Header("--- Player ---")]
    public float CurrentHealth;

    [Range(0.0f, 100.0f)]
    public float MaxHealth;

    [SerializeField]
    [Range(0.0f, 10.0f)]

    //Cooldown so the player can't take a hit every frame from the enemy
    private float attackCooldown;
    private bool Attacktrue;

    private void Start()
    {
        CurrentHealth = MaxHealth;


        Attacktrue = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Get damage from an enemy when the player object touches it
        if (other.gameObject.tag == "Enemy")
        {
            if (Attacktrue){ 
            CurrentHealth -= other.gameObject.GetComponent<AIBehaviour>().attackStrength;

            Attacktrue = false;

            StartCoroutine(DamageCooldown());
            }
        }

    }
    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        Attacktrue = true;

    }

}
