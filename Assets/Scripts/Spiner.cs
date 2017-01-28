using UnityEngine;
using System.Collections;

public class Spiner : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 30;
        //speed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion rot = Quaternion.Euler(0.0f, speed, 0.0f);
        transform.rotation = rot * transform.rotation;
	}
}
