using UnityEngine;
using System.Collections;

public class LevelClass {

	public bool passed = false;
	public string levelName = "";

	public LevelClass (bool pass, string name)		// Constructor
	{
		passed = pass;
		levelName = name;
	}

	public LevelClass (string name)		// Constructor
	{
		levelName = name;
	}

}
