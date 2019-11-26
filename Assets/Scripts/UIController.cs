using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text life; // Text to show the life of the player
    public Text gold; // Text to show the amount of gold
    public Text numberOfPotions; // Text to show the number of potions

    public Button usePotion; // Button to use the potion

    void Awake()
    {
        Button usePotionButton = usePotion.GetComponent<Button>(); // Get the component button from the game object
        usePotion.onClick.AddListener(consumePotion); // Give the button a listener function
    }

    // Update is called once per frame
    void Update()
    {
        updateText(); // Update the text if any of the player variables have been changed : player gold, player current and max lives, player potions
    }

    void updateText()
    {
        gold.text = "Gold : " + PlayerController.gold; // Display gold + the player gold
        life.text = "Lives : " + PlayerController.currentPlayerLives + " / " + PlayerController.maxPlayerLives; // Display gold + the player current and max lives
        numberOfPotions.text = "Health Potions : " + PlayerController.potions; // Display gold + the player gold
    }

    public void consumePotion()
    {
        if (PlayerController.potions >= 1f){ // if the player has 1 or more potions
            if (PlayerController.currentPlayerLives < PlayerController.maxPlayerLives) // And if player's current live is lower than its max life
            {
                PlayerController.currentPlayerLives += PlayerController.healthFromPotion; // add the float of the potion to the current lives
                if (PlayerController.currentPlayerLives > PlayerController.maxPlayerLives) // if the player's current live is higher than the max
                {
                    PlayerController.currentPlayerLives = PlayerController.healthFromPotion; // Set the health potion value back to max health
                }
                PlayerController.potions -= 1f; // Minus 1 potion from the variable
            }
        }
    }
}
