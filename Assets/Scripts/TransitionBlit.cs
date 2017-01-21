using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TransitionBlit : MonoBehaviour
{
    public Material TransitionMat;

    public bool transitioning = true;

    public bool countingDown = true;

	// Use this for initialization
	void Start ()
    {        

    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(transitioning == true)
        {
            if(TransitionMat.GetFloat("_Cutoff") <= 1 && !countingDown)
            {
                TransitionMat.SetFloat("_Cutoff", TransitionMat.GetFloat("_Cutoff") + Time.fixedDeltaTime);
            }
            else if(TransitionMat.GetFloat("_Cutoff") >= 0)
            {
                TransitionMat.SetFloat("_Cutoff", TransitionMat.GetFloat("_Cutoff") - Time.fixedDeltaTime);
            }
            else if(transitioning && countingDown)
            {
                transitioning = false;
                countingDown = false;
                TransitionMat.SetFloat("_Cutoff", 0);
            }
        }
<<<<<<< HEAD
=======

        //Debug.Log(TransitionMat.GetFloat("_Cutoff"));
>>>>>>> 8ba49292e727975872e1e18a8c2d1e27031c2173
	}

    public bool transitioned()
    {
        return (TransitionMat.GetFloat("_Cutoff") >= 1);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if(TransitionMat != null)
        {
            Graphics.Blit(src, dst, TransitionMat);
        }
    }
}
