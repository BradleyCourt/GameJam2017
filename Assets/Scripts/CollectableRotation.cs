﻿using UnityEngine;
using System.Collections;

public class CollectableRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Rotate(0, 1, 0);
    }
}