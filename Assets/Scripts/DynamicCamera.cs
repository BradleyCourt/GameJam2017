using UnityEngine;
using System.Collections;

public class DynamicCamera : MonoBehaviour
{
    public GameObject[] TargetList = null; // List of player controlled gameobjects to follow

    public Vector3 startLocation = Vector3.zero;

    public float smoothing = .1f; // Follow speed of camrea

    public float offSet = 5f;

    [SerializeField]
    float cameraDistance = 20;

    Camera cam; // reference to camera

    float tanFOV; 

    float aspectRatio;

    public bool starting = false;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;

        if (startLocation.z != 0)
            cameraDistance = -startLocation.z;

        tanFOV = Mathf.Tan(Mathf.Deg2Rad * cam.fieldOfView / 2f);
        aspectRatio = Screen.width / Screen.height;
	}
	
    void Update()
    {
        if (starting)
            cam.transform.position = Vector3.Lerp(cam.transform.position, startLocation, smoothing / 3.5f);
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        Debug.Log("Fixed update ticking");
        if (TargetList.Length > 0) 
        {
            Vector3 focusPoint;

            if (TargetList.Length > 1)
            {
                float x = 0;
                float y = 0;
                focusPoint.z = 0;
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
            }
            else
            {
                //target.z = -Mathf.Lerp(cameraDistance, cameraDistance + TargetList[0].GetComponent<Rigidbody>().velocity.magnitude / 2, .5f);


                RaycastHit hit;

                if (Physics.Raycast(TargetList[0].transform.position, Vector3.down, out hit, cameraDistance))
                {
                    Debug.Log(hit.point);
                    if (hit.distance + offSet > cameraDistance)
                    {
                        //focusPoint.x = (hit.point.x + TargetList[0].transform.position.x) / 2;
                        //focusPoint.y = (hit.point.y + TargetList[0].transform.position.y) / 2;
                        //focusPoint.z = 0;
                        focusPoint = Vector3.Lerp(TargetList[0].transform.position, hit.point, smoothing * 2);

                        //target.y = Mathf.SmoothStep(cam.transform.position.y, focusPoint.y, smoothing);

                        target = Vector3.Lerp(cam.transform.position, focusPoint, smoothing);                        

                        //target.z = -(cameraDistance + hit.distance);

                       // target.z = -(((hit.distance / 2f / aspectRatio) / tanFOV) + offSet);
                        target.z = Mathf.SmoothStep(cam.transform.position.z, -(((hit.distance / 1.0f / aspectRatio) / tanFOV) + offSet), .05f);
                    }
                    else
                        target.z = Mathf.SmoothStep(cam.transform.position.z, -cameraDistance, .05f);
                    
                }
                else
                    target.z = Mathf.SmoothStep(cam.transform.position.z, -cameraDistance, .05f);
            }

            target.z = Mathf.Clamp(target.z, -200, -10);

            transform.position = Vector3.Lerp(transform.position, target, 1 - smoothing);
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(startLocation, 1);
    }

    public void Skip()
    {
        starting = false;
        cam.transform.position = startLocation;
    }

    public IEnumerator StageOverView()
    {        
        starting = true;
        yield return new WaitForSecondsRealtime(2);
        starting = false;
    }
}