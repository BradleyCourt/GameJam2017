using UnityEngine;
using UnityEngine.SceneManagement;
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

    TransitionBlit blit;

	public void CollectEgg (GameObject egg)
	{
		eggsCollected.Add(egg);
		checkLevelComplete();
	}

	public void checkLevelComplete ()
	{
		Debug.Log("checking if level complete");
		int count = 0;
		int smashCount = 0;
		foreach (GameObject egg in eggs)		// Check each egg in the level
		{
			bool collected = false;
			foreach (GameObject egg2 in eggsCollected)		// Check which eggs have been collected
			{
				if (egg == egg2)		// Finds a match if the egg has been collected
				{
					collected = true;
					count++;
					break;
				}
			}

			if (!collected)		// If the egg has not been collected
			{
				// Check if the egg has smashed
				if (!egg.activeSelf)
				{
					// Egg is smashed
					smashCount++;
				}
			}
		}

		if (count + smashCount >= eggs.Length)		// Check if all the eggs have been collected or smashed
		{
			if (count >= eggsRequired)		// Enough eggs were collected to pass!
			{
				LevelClass lc = GameManager.LevelByName(SceneManager.GetActiveScene().name);
				if (lc != null)		// Found the current level in the level list
				{
					Debug.Log("Completed the level with " + eggsCollected.Count + " of " + eggs.Length + " eggs collected. " + collected + " of " + collectibles.Length + " were collected");
					lc.Complete (collected, eggsCollected.Count, hitsLeft, timeLeft);
				}
			}
			else
			{
				// The level was failed and needs to be restarted
				restartLevel();
			}
		}
	}

	private void restartLevel()
	{
		StartCoroutine(animationHandler(0.7f));

		//Time.timeScale = 1f;
	}

	private IEnumerator animationHandler(float t)
	{
		yield return new WaitForSeconds(1.5f);
        blit.transitioning = true;
        yield return new WaitForSeconds(1);
        AsyncOperation ao = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
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

        blit = FindObjectOfType<TransitionBlit>();

		// TODO: DELETE THIS ONCE IT IS PROPERLY INITIALIZED
        StartCoroutine(fadeInStart());
		GameManager.currentLevelData = this;

		// Initialize hits and time left
		hitsLeft = totalHits;
		timeLeft = totalTime;
    }

    private IEnumerator fadeInStart()
    {
        blit.transitioning = true;
        blit.countingDown = true;
        blit.TransitionMat.SetFloat("_Cutoff", 1.1f);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1.5f);
        //Time.timeScale = 1;
		GameManager.Playing = false;		// This pauses the game timer until the first move is made
    }
}
