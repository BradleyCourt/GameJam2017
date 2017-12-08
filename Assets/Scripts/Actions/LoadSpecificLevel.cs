using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificLevel : Action {

    public string sceneName = "";
    public PauseMenu pausemenu;

    void Start() {
        pausemenu = PauseMenu.FindObjectOfType<PauseMenu>();
    }

    public override void Execute()
    {
		SceneManager.LoadScene(sceneName);
        pausemenu.UnPause();
    }
}
