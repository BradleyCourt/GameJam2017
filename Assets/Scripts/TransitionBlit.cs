using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TransitionBlit : MonoBehaviour
{
    public Material TransitionMat;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if(TransitionMat != null)
        {
            Graphics.Blit(src, dst, TransitionMat);
        }
    }
}
