using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    // Use this for initialization
    void Start()
    {
		if (pauseMenu)		// Verify the pause menu is specified
		{
			if (GameManager.Paused)
			{
				pauseMenu.SetActive(true);
			}
			else
				pauseMenu.SetActive(false);
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("escape") && !GameManager.Paused)
        {
            pauseGame();
        }
		else if (Input.GetKeyDown("escape") && GameManager.Paused)
        {
            UnPause();
        }
    }
    void pauseGame()
    {
        pauseMenu.SetActive(true);
		Time.timeScale = 0;
		GameManager.Paused = true;

    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
		Time.timeScale = 1;
		GameManager.Paused = false;
    }

}
