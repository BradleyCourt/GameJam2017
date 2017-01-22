using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public Text uiElement;
	public string prefix = "";

	void Update ()
    {
		if (GameManager.currentLevelData && GameManager.Playing)		// If a level is loaded
		{
			GameManager.currentLevelData.timeLeft -= Time.deltaTime;

			if (uiElement)		// If a UI text-element has been specified
			{
				float timeLeft = GameManager.currentLevelData.timeLeft;
				if (timeLeft > 0)
					uiElement.text = string.Format(prefix + " {0}:{1:00}", (int)timeLeft / 60, (int)timeLeft % 60);
				else
					uiElement.text = prefix + " 0:00";
			}

			if (GameManager.currentLevelData.timeLeft <= 0)
			{
				// TODO restart game
			}
		}
	}
}
