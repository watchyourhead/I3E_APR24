/*
 * Author: Elyas Chua-Aziz
 * Date: 06/05/2024
 * Description: 
 * Contains functions related to the Player such as increasing score.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public GameManagerSO GameManager;

    /// <summary>
    /// The current score of the player
    /// </summary>
    int currentScore = 0;

    /// <summary>
    /// Store the current door in front of the player
    /// </summary>
    Door currentDoor;

    /// <summary>
    /// Store the current collectible that the player is touching
    /// </summary>
    Collectible currentCollectible;


    /// <summary>
    /// Increases the score of the player by <paramref name="scoreToAdd"/>
    /// </summary>
    /// <param name="scoreToAdd">The amount to increase by</param>
    public void IncreaseScore(int scoreToAdd)
    {
        // Increase the score of the player by scoreToAdd
        //currentScore += scoreToAdd;

        GameManager.IncreasePlayerScore(scoreToAdd);

        scoreText.text = "Score: " + GameManager.playerScore.ToString();
    }

    public void UpdateDoor(Door newDoor)
    {
        currentDoor = newDoor;
    }

    public void UpdateCollectible(Collectible newCollectible)
    {
        currentCollectible = newCollectible;
    }

    void OnInteract()
    {
        if(currentDoor != null)
        {
            // Interact with the object
            currentDoor.OpenDoor();
        }

        // Do a null check for the currentCollectible
        if(currentCollectible != null)
        {
            IncreaseScore(currentCollectible.myScore);
            currentCollectible.Collected();
        }
    }
}
