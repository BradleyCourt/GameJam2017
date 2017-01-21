using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ReloadLevel : Action {

    public override void Execute()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
