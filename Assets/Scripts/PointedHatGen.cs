using UnityEngine;
using System.Collections;

public class PointedHatGen : MonoBehaviour {

    public GameObject pointed_hat;
    public float max_r = 20.0f;
    public int max_hats = 50;
    int num_hats = 0;

	void Start () {
	
	}
	
	
	void Update () {
	    if (Time.frameCount % 7 == 0)
        {
            if (num_hats < max_hats)
            {
                float rad = 2.0f * Mathf.PI * (1.0f * num_hats / max_hats + (Random.value-0.5f) / max_hats);
                float rand = 0.05f * Random.value + 0.45f;
                Vector3 pos = new Vector3(max_r * rand * Mathf.Cos(rad), 0, max_r * rand * Mathf.Sin(rad));
                GameObject obj = (GameObject)Instantiate(pointed_hat, Vector3.zero, Quaternion.identity);
                obj.transform.parent = transform;
                obj.transform.localPosition = pos;
                num_hats += 1;
            }
            else
            {
                //Destroy(this);
            }
        }
        transform.Rotate(0, 0.01f, 0);
	}
}
