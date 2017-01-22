using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectButton : MonoBehaviour {

	public int level;
	private Button btn;

	void Start () 
	{
		btn = GetComponent<Button>();
	}

	void Update () 
	{
		if (btn)
		{
			if (level == 0)
				btn.interactable = true;
			else
			{
				if (GameManager.levels.Length > level)
					btn.interactable = GameManager.levels[level - 1].passed;
			}
		}
	}
}
