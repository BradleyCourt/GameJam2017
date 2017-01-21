using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	[HideInInspector] public int collected = 0;
	public int collectiblesRequired = 0;

	public GameObject[] eggs;
	private List<GameObject> eggsCollected = new List<GameObject>();
	public int eggsRequired = 0;

	public void CollectEgg (GameObject egg)
	{
		GameManager.currentLevelData.eggsCollected.Add(egg);
		checkLevelComplete();
	}

	private void checkLevelComplete ()
	{
		//foreach (GameObject egg in eggs)
		//{
		//	
		//}
	}

	void Start () 
	{
		// Ensure the level does not require more collectibles than available to pass
		if (collectiblesRequired > collectibles.Length)
		{
			collectiblesRequired = collectibles.Length;
		}

		// Do the same with eggs
		if (eggsRequired > eggs.Length)
		{
			eggsRequired = eggs.Length;
		}

		// Initialize hits and time left
		hitsLeft = totalHits;
		timeLeft = totalTime;

		// TODO: DELETE THIS ONCE IT IS PROPERLY INITIALIZED
		GameManager.currentLevelData = this;
	}

	void Update () 
	{
	
	}
}
