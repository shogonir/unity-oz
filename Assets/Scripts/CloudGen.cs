using UnityEngine;
using System.Collections;

public class CloudGen : MonoBehaviour {

    public GameObject[] clouds;
    public int max_clouds = 10;
    public float max_height = 10.0f;
    public float min_height =  0.0f;
    public int interval = 19;
    public float radius = 50.0f;

    int num_clouds = 0;
    float rotate;

	void Start () {
        rotate = (Random.value - 0.5f) * 0.01f;
	}
	
	void Update () {
	    if (num_clouds < max_clouds && Time.frameCount % interval == 0)
        {
            GameObject obj = (GameObject)Instantiate(clouds[Random.value < 0.5f ? 0 : 1], Vector3.zero, transform.rotation);
            obj.transform.parent = transform;
            float rad = 2.0f * Mathf.PI * (1.0f * num_clouds / max_clouds + (Random.value-0.5f) / max_clouds);
            float h = min_height + Random.value * (max_height - min_height);
            obj.transform.localPosition = new Vector3(radius * Mathf.Cos(rad), h, radius * Mathf.Sin(rad));
            float rand = Random.value * 6 + obj.transform.localScale.x;
            obj.transform.localScale = new Vector3(rand, rand, rand);
            obj.transform.LookAt(new Vector3(0, h, 0));
            if (Random.value < 0.5f)
            {
                obj.transform.Rotate(0, 180, 0);
            }
            num_clouds += 1;
        }
        if (num_clouds >= max_clouds)
        {
            Destroy(this);
        }
        //transform.Rotate(0, rotate, 0);
	}
}
