using UnityEngine;
using System.Collections;

public class DestroyObject : Action {

	public GameObject toDestroy;

	public override void Execute ()
	{
		if (toDestroy)
			Destroy(toDestroy);
	}
}
