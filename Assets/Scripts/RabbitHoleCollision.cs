using UnityEngine;
using System.Collections;

public class RabbitHoleCollision : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        // Check if the collided object is tagged as "Player"
        if (col.collider.tag == "Player")
        {
            EggSmash[] eggs = col.gameObject.GetComponents<EggSmash>();
            Debug.Log(eggs.Length);
            if (eggs.Length > 0)
            {
                foreach(EggSmash E in eggs)
                {
                    E.Smash();
                }
            }
            // Find all instances of EggSmash script on the collided object
            
            // For each smash script, call the Smash() function.
        }



    }
}
