using UnityEngine;
using System.Collections;

public class Twinkle : MonoBehaviour {

    public Material[] mats;
    public GameObject[] objs;

    int interval = 30;
    int mode = 0;

	void Start () {
	
	}
	
	void Update () {
	    if (Time.frameCount % interval == 0)
        {
            objs[0].GetComponent<MeshRenderer>().material = mats[(mode+2)%3];
            objs[1].GetComponent<MeshRenderer>().material = mats[(mode+2)%3];
            objs[2].GetComponent<MeshRenderer>().material = mats[(mode+1)%3];
            objs[3].GetComponent<MeshRenderer>().material = mats[(mode+0)%3];
            mode = (mode + 1) % 3;
        }
	}
}
