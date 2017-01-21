using UnityEngine;
using System.Collections;

public class ShockHandler : MonoBehaviour
{

    public static float distance = 10.0f;
    public static float force = 15.0f;
    public static float time = 0.2f;

    // Declared here to prevent variable declaration each time the screen is tapped
    private RaycastHit[] hits;
    private RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)     // Check the player has clicked
        {
            // Find all objects beneath the click
            hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (hits.Length > 0)
            {
                foreach (RaycastHit h in hits)      // Loop through all hits and find the hit-plane
                {
                    if (h.transform.tag == "ClickPlane")
                    {
                        hit = h;
                        break;
                    }
                }

                if (hit.collider != null)       // Verify that the click-plane exists and was hit
                {
                    CreateShockWave(hit.point);     // Create a shock wave
                }
            }
        }

    }

    private void CreateShockWave(Vector2 pos)
    {
        if (GameManager.currentLevelData)
        {
            if (GameManager.currentLevelData.hitsLeft > 0 && GameManager.currentLevelData.timeLeft > 0)
            {
                GameManager.currentLevelData.hitsLeft -= 1;

                // Create a new shockwave on an empty GameObject
                GameObject go = new GameObject();
                Shockwave sw = go.AddComponent<Shockwave>();

                // Start the shockwave at position pos
                sw.StartShockwave(pos);
            }
        }
    }
}
