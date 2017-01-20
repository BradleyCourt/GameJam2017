using UnityEngine;
using System.Collections;

public class RippleTrigger : MonoBehaviour
{
    int waveNumber = 0;

    public float distanceX;
    public float distanceY;
    public float[] waveAmplitude = new float[8];
    public float dampen = 1;
    public float waveLoss = .99f;
    public Vector2[] impactPOS = new Vector2[8];
    public float[] distance = new float[8];
    public float spreadSpeed;

    Renderer rend;
    Mesh mesh;

	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
        mesh = GetComponent<MeshFilter>().mesh;
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < 8; ++i) 
        {
            waveAmplitude[i] = rend.material.GetFloat("_WaveAmplitude" + (i + 1));
            if (waveAmplitude[i] > 0)
            {
                distance[i] += spreadSpeed;
                rend.material.SetFloat("_Distance" + (i + 1), distance[i]);
                rend.material.SetFloat("_WaveAmplitude" + (i + 1), waveAmplitude[i] * waveLoss);
            }
            if(waveAmplitude[i] < .05)
            {
                rend.material.SetFloat("_WaveAmplitude" + (i + 1), 0);
                distance[i] = 0;
            }
        }


            AddRipple(new Vector3(0, 0, 0));

    }

    void AddRipple(Vector3 pos)
    {
        if (waveNumber == 8)
        {
            waveNumber = 0;
        }

        Debug.Log("adding");

        waveAmplitude[waveNumber] = 0;
        distance[waveNumber] = 0;

        distanceX = transform.position.x - pos.x;
        distanceY = transform.position.z - pos.z; // might need to be z
        impactPOS[waveNumber].x = pos.x;
        impactPOS[waveNumber].y = pos.z; // might need to be z

        rend.material.SetFloat("_xImpact" + (waveNumber + 1), pos.x);
        rend.material.SetFloat("_zImpact" + (waveNumber + 1), pos.y); // might need to be changed

        rend.material.SetFloat("_OffsetX" + (waveNumber + 1), distanceX / mesh.bounds.size.x);
        rend.material.SetFloat("_OffsetZ" + (waveNumber + 1), distanceY / mesh.bounds.size.y); // mismatch because due to conversion to 2d

        rend.material.SetFloat("_WaveAmplitude" + (waveNumber + 1), 1 * dampen); //arbitary number here fix later

        waveNumber++;
        Debug.Log(waveNumber);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.rigidbody)
        {
            if (waveNumber == 8) 
            {
                waveNumber = 0;
            }

            waveAmplitude[waveNumber] = 0;
            distance[waveNumber] = 0;

            distanceX = transform.position.x - col.transform.position.x;
            distanceY = transform.position.y - col.transform.position.y; // might need to be z
            impactPOS[waveNumber].x = col.transform.position.x;
            impactPOS[waveNumber].y = col.transform.position.y; // might need to be z

            rend.material.SetFloat("_xImpact" + (waveNumber + 1), col.transform.position.x);
            rend.material.SetFloat("_zImpact" + (waveNumber + 1), col.transform.position.y); // might need to be changed

            rend.material.SetFloat("_OffsetX" + (waveNumber + 1), distanceX / mesh.bounds.size.x);
            rend.material.SetFloat("_OffsetZ" + (waveNumber + 1), distanceY / mesh.bounds.size.z); // mismatch because due to conversion to 2d

            rend.material.SetFloat("_WaveAmplitude" + (waveNumber + 1), col.rigidbody.velocity.magnitude * dampen);

            waveNumber++;

        }
    }
}
