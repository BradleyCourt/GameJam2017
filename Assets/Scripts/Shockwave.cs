using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shockwave : MonoBehaviour {

	private Vector2 point = Vector2.zero;
	private List<Rigidbody> affected = new List<Rigidbody>();

	public void StartShockwave (Vector2 pos)		// Start the shockwave
	{
		point = pos;

		StartCoroutine(growth());

	}

	private IEnumerator growth ()		// Handles the shockwave's growth
	{
		float currentTime = 0.0f;		// Tracks the time since the shockwave started

		while (currentTime < ShockHandler.time)
		{
			currentTime += Time.deltaTime;

			float percentage = currentTime / ShockHandler.time;		// Calculate how far through the shockwave we are
			force(percentage);		// Apply forces
			yield return null;
		}

		Destroy(gameObject);
	}

	private void force (float percentage)		// Handles the shockwave/s force output
	{
		float currentEnergy = ShockHandler.force * (1 - percentage);		// Get the current force based on distance from center of the shockwave
		float currentRadius = ShockHandler.distance * percentage;		// Get the current radius of the shockwave (how far it has reached)

		Collider[] colliders = Physics.OverlapSphere(point, currentRadius);		// Get all colliders within the current radius

		foreach (Collider c in colliders)
		{
			Rigidbody rb = c.GetComponent<Rigidbody>();
			if (rb)		// Check if the collider has an attached rigidbody component
			{
				if (!affected.Contains(rb))
				{
					affected.Add(rb);		// Add the rigidbody to the affected list so it is not affected again

					// Apply a force to the rigidbody
					Vector2 newForce = new Vector2(rb.transform.position.x, rb.transform.position.y) - point;
					newForce.Normalize();
					newForce *= currentEnergy;
					if (rb.velocity.y < 0 && newForce.y > 0)
						rb.velocity = Vector3.zero;
					rb.AddForce(newForce, ForceMode.Impulse);
				}
			}
		}
	}
}
