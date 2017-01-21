using UnityEngine;
using System.Collections;

public class BlastWaveController : MonoBehaviour
{
    ParticleSystem emitter;

	// Use this for initialization
	void Start ()
    {
        emitter = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public bool Play()
    {
        if (!emitter.isPlaying)
        {
            emitter.Play();
            return true;
        }
        return false;
    }

    public bool isPlaying()
    {
        return emitter.isPlaying;
    }


}
