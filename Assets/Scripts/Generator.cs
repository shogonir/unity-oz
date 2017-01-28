using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

    public GameObject element;
    public int max_elements = 10;
    public float radius = 10.0f;
    public int interval = 1;
    public float rotate_speed = 0.0f;
    public float rotate_y = 0f;
    public float base_y = 0f;
    public Vector3 rotate;

    int num_elements = 0;

	void Start () {
	
	}
	
	void Update () {
	    if (num_elements < max_elements && Time.frameCount % interval == 0)
        {
            float rad = 2.0f * Mathf.PI * num_elements / max_elements;
            Vector3 pos = new Vector3(radius * Mathf.Cos(rad), base_y, radius * Mathf.Sin(rad));
            GameObject ele = (GameObject)Instantiate(element, Vector3.zero, Quaternion.identity);
            ele.transform.parent = transform;
            ele.transform.localPosition = pos;
            ele.transform.LookAt(Vector3.zero);
            ele.transform.Rotate(rotate.x, 0, 0);
            ele.transform.Rotate(0, rotate.y, 0);
            ele.transform.Rotate(0, 0, rotate.z);
            num_elements += 1;
        }
        transform.Rotate(0, rotate_speed, 0);
	}
}
