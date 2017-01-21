using UnityEngine;
using System.Collections;

public class QuitGame : Action {

    public override void Execute()
    {
        Application.Quit();
    }
}
