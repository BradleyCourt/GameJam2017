using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameManager.currentLevelData.timeLeft -= Time.deltaTime;
        if (GameManager.currentLevelData.timeLeft <= 0)
        {
            // TO DO restart game
        }
	}
}
