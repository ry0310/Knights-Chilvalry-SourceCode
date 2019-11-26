using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public static float eHth = 3f; // Amount of health the enemy has

    public GameObject bloodParticle; // Get the game object particle system and name is bloodParticles

    // Start is called before the first frame update
    public void RemoveHealth(float amount) // Remove health according to the amount of damage in the player controller script
    {
        eHth -= amount; // Reduce the health
        if (eHth <= 0) // If enemy health is below or equals to 0
        {
            Destroy(this.gameObject); // Destroy the game object
            Instantiate(bloodParticle, transform.position, Quaternion.identity); // Spawn the particle system on the game object
            PlayerController.gold += 1; // Add 1 gold to the player
        }
    }
}
