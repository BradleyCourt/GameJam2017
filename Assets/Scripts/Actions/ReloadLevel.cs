using UnityEngine;
using System.Collections;

public class ReloadLevel : Action {

    public override void Execute()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
