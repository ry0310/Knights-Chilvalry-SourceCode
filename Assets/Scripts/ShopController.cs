using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Button healthPotion; // Add a button called health potion
    public Button maxLife; // Add a button called max life
    public Button close; // Add a button called close

    public GameObject shopPanel; // Add a game object for the shop menue

    public bool itemBought; // Add a bool to set whether the player can buy items or not

    void Awake()
    {
        shopPanel.gameObject.SetActive(false); // Disable the shop menu

        Button potionBtn = healthPotion.GetComponent<Button>(); // Find the button component
        Button maxLifeBtn = maxLife.GetComponent<Button>(); // Find the button component
        Button closeBtn = close.GetComponent<Button>(); // Find the button component

        potionBtn.onClick.AddListener(addPotion); // Add a listener so that the button runs the method addPotion
        maxLifeBtn.onClick.AddListener(increaseMaxLife); // Add a listener so that the button runs the method increaseMaxLife
        closeBtn.onClick.AddListener(closeShop); // Add a listener so that the button runs the method closeShop

        itemBought = false;
    }

    public void addPotion()
    {
        if (PlayerController.gold >= 5f && itemBought == false) // Check if the player has more than 5 gold and has not bought an item
        {
            itemBought = true; // Set the bool to true
            PlayerController.potions += 1f; // Add 1 potion to the variable
            PlayerController.gold -= 5f; // Deduct 5 float from gold
            itemBought = false; // Set the bool back to false
        }
    }

    public void increaseMaxLife()
    {
        if (PlayerController.gold >= 10f && itemBought == false) // Check if the player has more than 10 gold and has not bought an item
        {
            itemBought = true; // Set the bool to true
            PlayerController.maxPlayerLives += 1f; // Add 1 float to max life
            PlayerController.currentPlayerLives += 1f; // Add 1 to current life
            PlayerController.gold -= 10f; // Deduct 10 gold
            itemBought = false; // Set the bool back to false
        }
    }

    public void closeShop()
    {
        if (Time.timeScale == 0f) // If the time scale is paused
        {
            Time.timeScale = 1f; // Set it to 1
            shopPanel.gameObject.SetActive(false); // Close the shop menu
        }
    }

    void OnCollisionEnter2D(Collision2D col) // Add a collision factor for the shop keeper
    {
        if (col.gameObject.tag == "Player") // Check if the object has the tag "Player"
        {
            shopPanel.gameObject.SetActive(true); // Set the shop menu to active
            Time.timeScale = 0f; // Stop the time
        }
    }
}
