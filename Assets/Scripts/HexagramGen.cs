using UnityEngine;
using System.Collections;

public class HexagramGen : MonoBehaviour {

    public GameObject[] hexs;
    public int max_hexs = 10;
    public float radius = 10f;

    int num_hexs = 0;

	void Start () {
	
	}
	
	void Update () {
	    if (num_hexs < max_hexs && Time.frameCount % 17 == 0)
        {
            Vector3 pos = new Vector3(0, 8, 0);
            GameObject obj = (GameObject)Instantiate(hexs[Random.Range(0, hexs.Length)], pos, transform.rotation);
            obj.transform.parent = transform;
            float r = (0.5f+0.5f*Random.value) * radius;
            float rad = 2.0f * Mathf.PI * (1.0f * num_hexs / max_hexs + (Random.value-0.5f) / max_hexs);
            obj.transform.localPosition = new Vector3(r * Mathf.Cos(rad), 0, r * Mathf.Sin(rad));
            obj.transform.LookAt(new Vector3(0, 8, 0));
            obj.transform.Rotate(0, 0, 90);
            num_hexs += 1;
        }
        if (num_hexs >= max_hexs)
        {
            Destroy(this);
        }
	}
}
