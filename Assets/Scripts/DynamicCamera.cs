using UnityEngine;
using System.Collections;

public class DynamicCamera : MonoBehaviour
{
    public GameObject[] TargetList = null; // List of player controlled gameobjects to follow

    public float smoothing = .3f; // Follow speed of camrea

    public float offSet = 5f;

    [SerializeField]
    float cameraDistance = -10;

    Camera cam; // reference to camera

    float tanFOV; 

    float aspectRatio;    

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
        tanFOV = Mathf.Tan(Mathf.Deg2Rad * cam.fieldOfView / 2f);
        aspectRatio = Screen.width / Screen.height;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (TargetList.Length > 0) 
        {
            Vector3 focusPoint;

            if (TargetList.Length > 1)
            {
                float x = 0;
                float y = 0;
                foreach (GameObject g in TargetList)
                {
                    x += g.transform.position.x;
                    y += g.transform.position.y;
                }

                focusPoint = new Vector3(x / TargetList.Length, y / TargetList.Length, 0);
            }
            else
            {
                focusPoint = TargetList[0].transform.position;
            }

            Vector3 target = Vector3.Lerp(transform.position, focusPoint, smoothing);            

            float distance = distanceCheck();

            if (distance + offSet > cameraDistance)
            {
                target.z = -(((distance / 2f / aspectRatio) / tanFOV) + offSet);
            }
            else
            {
                target.z = -cameraDistance;
            }

            transform.position = target;
        }        
    }


    // Very expensive can be optimized if size of stage is known
    float distanceCheck()
    {
        float distance = 0;

        foreach (GameObject g in TargetList)
        {
            foreach (GameObject other in TargetList)
            {
                if (new Vector3(g.transform.position.x - other.transform.position.x, g.transform.position.y - other.transform.position.y).magnitude > distance)
                {
                    distance = new Vector3(g.transform.position.x - other.transform.position.x, g.transform.position.y - other.transform.position.y).magnitude;
                }
            }
        }

        return distance;
    }
}
