using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RemainingHits : MonoBehaviour {

	public Text uiElement;
	public string prefix = "";

	void Update () 
	{
		if (GameManager.currentLevelData && GameManager.Playing)		// If a level is loaded
		{
			if (uiElement)		// If a UI text-element has been specified
			{
				float hitsLeft = GameManager.currentLevelData.hitsLeft;
				if (hitsLeft > 0)
					uiElement.text = string.Format(prefix + " " + hitsLeft);
				else
					uiElement.text = prefix + " ";
			}
		}
	}
}
