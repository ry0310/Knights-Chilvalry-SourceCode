using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private GameObject target; // Set a variable for an enemy game object //

    public static float maxPlayerLives = 3f; // Give player health //
    public static float currentPlayerLives = 3f; // Give player health //

    public float maxDistance; // Set max distance for attacking //
    public LayerMask NumberOfEnemies; // Set the layer for number of enemies
    public LayerMask Chest; // Set the layer 

    public static float gold = 1f; // Add a float for the gold
    public static float potions = 0f; // Add a float for the potions
    public static float healthFromPotion = 3f; // Add a float for how much the user can get from the gold

    public float damage = 1f; // Add a float for the damage
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Player Death
        if (currentPlayerLives == 0) // If lives reach 0
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
            currentPlayerLives = 3; // Set the health back to 3
            maxPlayerLives = 3; // Set the max health to 3 again
        }
    }

    public void movement()
    {
        // Horizontal Movement
        Vector3 horizontalAxis = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f); // Set direction of horizontal movement //
        transform.position = transform.position + horizontalAxis * Time.deltaTime; // Give the direction speed //
        // Vertical Movement
        Vector3 verticalAxis = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f); // Set direction of vertical movement //
        transform.position = transform.position + verticalAxis * Time.deltaTime; // Give the direction speed //
    }

    void FixedUpdate()
    {
        movement(); // Run the movement function

        if (Input.GetMouseButtonDown(0)) // When player press left click and the distance between the enemy is lesser than the max distance //
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, maxDistance, NumberOfEnemies); // Get the position of the player, measures out the max distance and get the total amount of enemies
            for (int i = 0; i < enemies.Length; i++) // For each enemies in the array
            {
                enemies[i].GetComponent<EnemyHealthScript>().RemoveHealth(damage); // Get the enemy with the enemy within the physics circle and the health script
            }

            Collider2D[] Interactibles = Physics2D.OverlapCircleAll(transform.position, maxDistance, Chest); // Get the positions of the chest, number and how far away are they from the player
            for (int i = 0; i < Interactibles.Length; i++) // An array for the chest
            {
                Interactibles[i].GetComponent<objectInteraction>().interactable(); // Get the interactible method from the object interatcion script
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // Make the color of the gizmos red to see better in the scene manager
        Gizmos.DrawWireSphere(transform.position, maxDistance); // Draw out the circle from the player's position and the max distance the player can deal damage
    }

    void OnCollisionEnter2D(Collision2D col) // Player collision
    {
        if (col.gameObject.tag.Equals("Enemy")) // Check if the object the player is colliding has the tag "Enemy"
        {
            currentPlayerLives -= 1; // Deduct a life point from the player
        }
    }
}
