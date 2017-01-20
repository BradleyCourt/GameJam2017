using UnityEngine;
using System.Collections;

/* DESCRIPTION
 * One instance, controls 
 */

public static class GameManager {

	public static LevelData currentLevelData = null;

	public static bool paused = false;		// Toggled when the pause menu is displayed
	public static bool playing = true;		// Should be false when time runs out, etc

}
