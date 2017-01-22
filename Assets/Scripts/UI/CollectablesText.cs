using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectablesText : MonoBehaviour {

	public Text uiElement;
	public string prefix = "";

	void Update () 
	{
		if (GameManager.currentLevelData && GameManager.Playing)		// If a level is loaded
		{
			if (uiElement)		// If a UI text-element has been specified
			{
				uiElement.text = prefix + " " + GameManager.currentLevelData.collected + " / " + 
					GameManager.currentLevelData.collectibles.Length + " (req. " + GameManager.currentLevelData.collectiblesRequired + ")";
			}
		}
	}
}
