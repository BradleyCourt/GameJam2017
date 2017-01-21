using UnityEngine;
using System.Collections;

public class LevelClass {

	public bool passed = false;
	public string levelName = "";

	// Track high scores
	public int hsCollectibles = 0;
	public int hsEggs = 0;
	public int hsWavesRemaining = 0;
	public float hsTime = 0.0f;

	public LevelClass (bool pass, string name)		// Constructor
	{
		passed = pass;
		levelName = name;
	}

	public LevelClass (string name)		// Constructor
	{
		levelName = name;
	}

	public void Complete (int collectibles, int eggs, int remainingWaves, float time)
	{
		passed = true;

		// Set high scores if applicable
		if (collectibles > hsCollectibles)
			hsCollectibles = collectibles;

		if (eggs > hsEggs)
			hsEggs = eggs;

		if (remainingWaves > hsWavesRemaining)
			hsWavesRemaining = remainingWaves;

		if ( (time < hsTime) || hsTime == 0.0f)
			hsTime = time;
	}

}
