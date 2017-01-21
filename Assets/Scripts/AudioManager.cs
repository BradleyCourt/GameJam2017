using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> AudioClips;

    public AudioSource aSource;

	// Use this for initialization
	void Start ()
    {
        aSource = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (!aSource.isPlaying)
        {
            playRandomClip();
        }
	}

    void playRandomClip()
    {
        if (AudioClips.Count > 1)
        {
            AudioClip temp = AudioClips[0];

            int index = Random.Range(1, AudioClips.Count - 1);

            AudioClips[0] = AudioClips[index];
            AudioClips[index] = temp;

            aSource.clip = AudioClips[0];
            aSource.Play();
        }
        else if( AudioClips.Count == 1)
        {
            aSource.clip = AudioClips[0];
            aSource.Play();
        }
    }

}
