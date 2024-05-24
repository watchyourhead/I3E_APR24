/*
 * Author: Elyas Chua-Aziz
 * Date: 06/05/2024
 * Description: 
 * The Collectible will destroy itself after being collided with.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    /// <summary>
    /// The score value that this collectible is worth.
    /// </summary>
    public int myScore = 5;

    /// <summary>
    /// Performs actions related to collection of the collectible
    /// </summary>
    public void Collected()
    {
        // Destroy the attached GameObject
        Destroy(gameObject);
    }

    /// <summary>
    /// Callback function for when a collision occurs
    /// </summary>
    /// <param name="collision">Collision event data</param>
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that
        // touched me has a 'Player' tag
        if(collision.gameObject.tag == "Player")
        {
            // Look for the "Player" component on the GameObject that collided with me.
            // Update the player that I am the current collectible.
            collision.gameObject.GetComponent<Player>().UpdateCollectible(this);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the object that
        // stopped touching me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            // Look for the "Player" component on the GameObject that collided with me.
            // Update the player that there is no current collectible.
            collision.gameObject.GetComponent<Player>().UpdateCollectible(null);
        }
    }


}
