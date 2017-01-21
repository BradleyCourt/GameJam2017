using UnityEngine;
using System.Collections;

public class BasketCollide : MonoBehaviour {

	void OnTriggerEnter (Collider col)		// Prevent eggs from breaking in the basket, remove velocity and mark as collected
	{
		if (col.tag == "Player")		// If an egg lands in the basket
		{
			Rigidbody rb = col.GetComponent<Rigidbody>();
			if (rb)		// Ensure the rigidbody exists
			{
				rb.velocity = Vector3.up;		// Remove velocity by adding a slight upwards velocity (will create a tiny bounce effect)
				Destroy(rb);
			}

			EggSmash smash = col.GetComponent<EggSmash>();		// Stop the egg from being smashable
			if (smash)
				Destroy(smash);

			Collider[] thisCols = col.gameObject.GetComponents<Collider>();
			if (thisCols.Length > 0)
			{
				foreach (Collider c in thisCols)
				{
					Destroy(c);
				}
			}

			// Record the egg as 'collected'
			if (GameManager.currentLevelData)
			{
				GameManager.currentLevelData.CollectEgg(col.gameObject);
			}
		}
	}
}
