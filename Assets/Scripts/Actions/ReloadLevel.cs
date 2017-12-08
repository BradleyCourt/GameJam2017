using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ReloadLevel : Action 
{
    public PauseMenu pausemenu;

    void Start() 
        {
        pausemenu = PauseMenu.FindObjectOfType<PauseMenu>();
    }

    public override void Execute()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pausemenu.UnPause();
    }
}
