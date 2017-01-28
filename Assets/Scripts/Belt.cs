using UnityEngine;
using System.Collections;

public class Belt : MonoBehaviour {

    public GameObject belt_red;
    public GameObject belt_bla;
    public GameObject belt_dig;

    public float radius = 10.0f;
    public int max_elements = 30;
    public float y = 0.0f;

    int num_elements = 0;
    float rotate_deg = 0.0f;

	void Start () {
        rotate_deg = 0.1f * (Random.value - 0.5f);
	}
	
	void Update () {
	    if (num_elements<max_elements && Time.frameCount % 11 == 0)
        {
            float rad;
            rad = 2.0f * Mathf.PI * num_elements / max_elements;
            Vector3 pos1 = new Vector3(radius * Mathf.Cos(rad), y, radius * Mathf.Sin(rad));
            num_elements += 1;
            rad = 2.0f * Mathf.PI * num_elements / max_elements;
            Vector3 pos2 = new Vector3(radius * Mathf.Cos(rad), y, radius * Mathf.Sin(rad));
            float magnitude = (pos1 - pos2).magnitude;
            float rand = Random.value;
            GameObject obj = rand<0.2f ? belt_dig : rand<0.5 ? belt_bla : belt_red;
            obj = (GameObject)Instantiate(obj, Vector3.zero, transform.rotation);
            obj.transform.parent = transform;
            obj.transform.localPosition = (pos1 + pos2) / 2.0f;
            float x = 0.196f * (rand < 0.2f ? magnitude : 256.0f * magnitude);
            Vector3 scale = obj.transform.localScale;
            obj.transform.localScale = new Vector3(x, scale.y, scale.z);
            obj.transform.LookAt(Vector3.zero);
            obj.transform.Rotate(0, 180, 0);
        }
        transform.Rotate(0, rotate_deg, 0);
	}
}
