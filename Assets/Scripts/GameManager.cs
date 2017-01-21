using UnityEngine;
using System.Collections;

/* DESCRIPTION
 * One instance, controls 
 */

public static class GameManager {

	public static LevelData currentLevelData = null;

	private static bool paused = false;		// Toggled when the pause menu is displayed
	public static bool playing = true;		// Should be false when time runs out, etc

	public static bool Paused
	{
		get { return paused; }
		set 
		{ 
			paused = value;
			if (paused)
			{
				Time.timeScale = 0;
			}
		}
	}


}
