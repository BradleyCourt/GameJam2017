using UnityEngine;
using System.Collections;

/* DESCRIPTION
 * This script will cause an egg to smash if it hits an object with too much force
 */

public class EggSmash : MonoBehaviour {

	public float smashVelocity = 10.0f;
	private Rigidbody rb;

	public Action[] onSmash;

	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Obstacle" || col.gameObject.tag == "Player")		// Only break against obstacles (not collectibles, etc)
		{
            if (rb)     // If the object has an attached rigidbody
            {
                if (col.relativeVelocity.magnitude >= smashVelocity)        // Check if the egg's velocity is too fast
                {
                    Smash();
                }
            }
        }
	}

	public void Smash ()
	{
        Debug.Log("SMASH!");
        foreach (Action a in onSmash)
        {
            if (a)
                a.Execute();
        }

		GameManager.currentLevelData.checkLevelComplete();
    }
}
