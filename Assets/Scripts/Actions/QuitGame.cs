using UnityEngine;
using System.Collections;

public class QuitGame : Action {
    public PauseMenu pausemenu;

    void Start() {
        pausemenu = PauseMenu.FindObjectOfType<PauseMenu>();
    }

    public override void Execute()
    {
        Application.Quit();
        pausemenu.UnPause();
    }
}
