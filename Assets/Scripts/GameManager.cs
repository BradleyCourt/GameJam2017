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
		
	public static LevelClass[] levels = new LevelClass[] 
	{ new LevelClass("Level_1"), new LevelClass("Level_2"), new LevelClass("Level_3"),
		new LevelClass("Level_4"), new LevelClass("Level_5"), new LevelClass("Level_6")
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

		if (levName = "")		// If all levels have been passed
		{
			return "MainMenu";
		}
		else
			return levName;
	}

}
