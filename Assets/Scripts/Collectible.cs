using UnityEngine;
using System.Collections;

/* DESCRIPTION
 * Placed on an object to turn the object into a collectible. When the player controlled
 * object collides with the collectible, it is taken and disappears.
 */

public class Collectible : MonoBehaviour {

	public bool collected = false;
	public int scoreValue = 0;

	public void OnCollisionEnter (Collision col)		// Handle pick-up event for the collectible
	{
		if (!collected) 		// Error check, should never be true as the GameObject should be disabled once it is collected
		{
			if (col.collider.tag == "Player")		// Check the collided object is a player controlled object (egg, etc)
			{
				if (GameManager.currentLevelData != null)
				{
					collected = true;		// Mark as collected

					GameManager.currentLevelData.collected += 1;

					gameObject.SetActive(false);
				}
			}
		}
	}

}
