using UnityEngine;
using System.Collections;

public class TestMoveToClick : MonoBehaviour
{
    Camera cam;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit2D hit = Physics2D.Raycast(cam.transform.position, cam.ViewportToWorldPoint(Input.mousePosition));

            Vector3 target = cam.ScreenToWorldPoint(Input.mousePosition);

            target.z = 0;

            transform.position = target;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(.5f, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(.5f, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, .5f, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, .5f, 0);
        }
    }
}
