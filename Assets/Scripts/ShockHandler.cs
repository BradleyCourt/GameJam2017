using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShockHandler : MonoBehaviour {

	public static float distance = 10.0f;
	public static float force = 25.0f;
	public static float time = 0.2f;

    [Tooltip("Shockwave emitter prefab here")]    
    public GameObject emitterPrefab;

    List<ParticleSystem> emitterPool = new List<ParticleSystem>();

	// Declared here to prevent variable declaration each time the screen is tapped
	private RaycastHit[] hits;
	private RaycastHit hit;

    void Start()
    {
        if (emitterPrefab == null)
        {
            Debug.Log("ShockHandler: Missing emitterPrefab");
        }

        for (int i = 0; i < 10; ++i) 
        {
            InstanstiateEmitter();
        }
    }

	void Update () 
	{
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
		{
			// WINDOWS CONTROLS
			if (Input.GetMouseButtonDown(0))		// Check the player has clicked
			{
				// Find all objects beneath the click
				hits = Physics.RaycastAll (Camera.main.ScreenPointToRay(Input.mousePosition));
				if (hits.Length > 0)
				{
					foreach (RaycastHit h in hits)		// Loop through all hits and find the hit-plane
					{
						if (h.transform.tag == "ClickPlane")
						{
							hit = h;
							break;
						}
					}

					if (hit.collider != null)		// Verify that the click-plane exists and was hit
					{
						// Prevent a turn from being used when skipping camera fade-in at the start of the game
						if (!GameManager.currentLevelData.playingIntro)
							CreateShockWave(hit.point);		// Create a shock wave
					}
				}
			}
		}
		else if (Application.platform == RuntimePlatform.Android)
		{
			// MOBILE CONTROLS
			foreach (Touch touch in Input.touches)
			{
				if (touch.phase == TouchPhase.Began)
				{
					// Find all objects beneath the tap
					hits = Physics.RaycastAll (Camera.main.ScreenPointToRay(touch.position));
					if (hits.Length > 0)
					{
						foreach (RaycastHit h in hits)		// Loop through all hits and find the hit-plane
						{
							if (h.transform.tag == "ClickPlane")
							{
								hit = h;
								break;
							}
						}

						if (hit.collider != null)		// Verify that the click-plane exists and was hit
						{
							// Prevent a turn from being used when skipping camera fade-in at the start of the game
							if (!GameManager.currentLevelData.playingIntro)
								CreateShockWave(hit.point);		// Create a shock wave
						}
					}
				}
			}
		}
	}

	private void CreateShockWave (Vector2 pos)
	{
		if (GameManager.currentLevelData)
		{
			if (GameManager.currentLevelData.hitsLeft > 0 && GameManager.currentLevelData.timeLeft > 0)
			{
				GameManager.Playing = true;
				GameManager.currentLevelData.hitsLeft -= 1;

				// Create a new shockwave on an empty GameObject
				GameObject go = new GameObject();
				Shockwave sw = go.AddComponent<Shockwave>();

                PlayEmitter(pos);

				// Start the shockwave at position pos
				sw.StartShockwave(pos);
			}
		}
	}

    void InstanstiateEmitter()
    {
        emitterPool.Add(Instantiate(emitterPrefab).GetComponent<ParticleSystem>());
    }



    void InstanstiateEmitter(Vector2 pos)
    {
        emitterPool.Add(Instantiate(emitterPrefab).GetComponent<ParticleSystem>());
        emitterPool[emitterPool.Count - 1].transform.position = new Vector3(pos.x, pos.y);
    }

    void PlayEmitter(Vector2 pos)
    {
        bool played = false;

        foreach (ParticleSystem e in emitterPool)
        {
            if (!e.isPlaying)
            {
                e.transform.position = new Vector3(pos.x, pos.y);
                played = true;
                e.Play();
            }
        }
        
        if(!played)
        {
            InstanstiateEmitter(pos);
            emitterPool[emitterPool.Count - 1].Play();
        }
    }
}
