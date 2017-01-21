using UnityEngine;
using System.Collections;

public class DynamicCamera : MonoBehaviour
{
    public GameObject[] TargetList = null; // List of player controlled gameobjects to follow

    public float smoothing = .1f; // Follow speed of camrea

    public float offSet = 5f;

    [SerializeField]
    float cameraDistance = 20;

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
	void FixedUpdate ()
    {
        if (TargetList.Length > 0) 
        {
            Vector3 focusPoint;

            if (TargetList.Length > 1)
            {
                float x = 0;
                float y = 0;
                foreach (GameObject g in TargetList) // Sums the x and y vavlues of all targets in list before dividing by length of list to find focus point
                {
					if (g.activeSelf)
					{
                    	x += g.transform.position.x;
                    	y += g.transform.position.y;
					}
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
                target.z = -(((distance / 2f / aspectRatio) / tanFOV) + offSet); // Calculates distance camera needs to be to fit both objects on screen
                Debug.Log((distance / 2f / aspectRatio) / tanFOV + offSet);
            }
            else
            {
                //target.z = -Mathf.Lerp(cameraDistance, cameraDistance + TargetList[0].GetComponent<Rigidbody>().velocity.magnitude / 2, .5f);

                target.z = -cameraDistance;
            }

            target.z = Mathf.Clamp(target.z, -200, -10);

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
                Vector3 temp = new Vector3(g.transform.position.x - other.transform.position.x, g.transform.position.y - other.transform.position.y);

                if (temp.magnitude > distance && g != other)
                {
                    distance = temp.magnitude;
                }
            }
        }

        return distance;
    }
}
