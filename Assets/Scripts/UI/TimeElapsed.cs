using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeElapsed : MonoBehaviour {

	public Text uiElement;
	public string prefix = "";

	void Update () 
	{
		if (GameManager.currentLevelData && GameManager.Playing)		// If a level is loaded
		{
			if (uiElement)		// If a UI text-element has been specified
			{
				float timeElapsed = GameManager.currentLevelData.totalTime - GameManager.currentLevelData.timeLeft;
				if (timeElapsed > 0)
					uiElement.text = string.Format(prefix + " {0}:{1:00}", (int)timeElapsed / 60, (int)timeElapsed % 60);
				else
					uiElement.text = prefix + "0:00";
			}
		}
	}
}
