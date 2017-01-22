using UnityEngine;
using System.Collections;

/* DESCRIPTION
 * One instance, controls 
 */

public static class GameManager {

	public static LevelData currentLevelData = null;

	private static bool paused = false;		// Toggled when the pause menu is displayed
	private static bool playing = true;		// Should be false when time runs out, etc

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

	public static bool Playing
	{
		get { return playing; }
		set
		{
			if (value != playing)
			{
				// Value has changed
				bool newVal = value;
				playing = value;
				if (newVal == true)
				{
					// Game is now playing, set timescale
					Time.timeScale = 1;
				}
				else
				{
					// Game play is stopping (player just respawned)
				}
			};
		}
	}
		
	public static LevelClass[] levels = new LevelClass[] 
	{ new LevelClass("Level1"), new LevelClass("Level2"), new LevelClass("Level3"),
		new LevelClass("Level4")
	};

	public static string nextLevel ()
	{
		string levName = "";
		foreach (LevelClass l in levels)
		{
			if (!l.passed)		// Find the first level which has not yet been passed
			{
				levName = l.levelName;
				break;
			}
		}

		if (levName == "")		// If all levels have been passed
		{
			return "StartScreen";
		}
		else
			return levName;
	}

	public static LevelClass LevelByName (string s)
	{
		foreach (LevelClass c in levels)
		{
			if (s == c.levelName)
				return c;
		}
		return null;
	}

}
