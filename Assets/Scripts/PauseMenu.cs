using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    //private bool isShowing;
    bool isPaused = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && !isPaused)
        {
            pauseGame();
        }
        else if (Input.GetKeyDown("escape") && isPaused)
        {
            UnPause();
        }
    }
    void pauseGame()
    {
        //pauseMenu.SetActive(isShowing);
        pauseMenu.SetActive(true);

            Time.timeScale = 0;
            isPaused = true;
            //isShowing = !isShowing;
            //pauseMenu.SetActive(isShowing);

    }

    public void UnPause()
    {
        print("yo");
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

}
