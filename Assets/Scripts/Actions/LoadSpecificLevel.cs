using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificLevel : Action {

    public string sceneName = "";

    public override void Execute()
    {
		SceneManager.LoadScene(sceneName);
    }
}
