using UnityEngine;
using System.Collections;

public class SpawnObject : Action
{
	public GameObject obj;

	public bool inheritPosition = true;
	public bool inheritRotation = true;
	public bool inheritScale = true;

	public override void Execute ()
	{
		if (obj)
		{
			GameObject newObj = Instantiate (obj);

			if (inheritPosition)
				newObj.transform.position = transform.position;
			if (inheritRotation)
				newObj.transform.rotation = transform.rotation;
			if (inheritScale)
				newObj.transform.localScale = transform.localScale;
		}
	}
}
