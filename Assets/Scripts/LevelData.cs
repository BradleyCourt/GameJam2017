using UnityEngine;
using System.Collections;

/* DESCRIPTION:
 * This script holds data for each level such as the amount of hits available, time limit, 
 * list of collectibles, etc.
 */

public class LevelData : MonoBehaviour {

	public int totalHits = 0;
	[HideInInspector] public int hitsLeft = 0;

	public float totalTime = 0.0f;
	[HideInInspector] public float timeLeft = 0.0f;

	public Collectible[] collectibles;
	public int collected = 0;
	public int collectiblesRequired = 0;

	void Start () 
	{
		// Ensure the level does not require more collectibles than available to pass
		if (collectiblesRequired > collectibles.Length)
		{
			collectiblesRequired = collectibles.Length;
		}

		// Initialize hits and time left
		hitsLeft = totalHits;
		timeLeft = totalTime;
	}

	void Update () 
	{
	
	}
}
