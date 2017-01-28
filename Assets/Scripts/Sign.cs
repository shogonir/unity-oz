using UnityEngine;
using System.Collections;

public class Sign : MonoBehaviour {

	void Start () {
        float div = 17500.0f;
        transform.localPosition = new Vector3(-Screen.width / div, -Screen.height / div, 0);
        Destroy(this);
	}
	
	void Update () {
	
	}
}
