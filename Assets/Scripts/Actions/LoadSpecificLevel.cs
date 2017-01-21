using UnityEngine;
using System.Collections;

public class LoadSpecificLevel : Action {

    public string sceneName = "";

    public override void Execute()
    {
        Application.LoadLevel(sceneName);
    }
}
