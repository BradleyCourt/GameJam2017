using UnityEngine;
using System.Collections;

public class SetEnableObject : Action {

	public bool state = false;
	public GameObject obj;

	public override void Execute ()
	{
		if (obj)
		{
			obj.SetActive(state);
		}
	}
}
