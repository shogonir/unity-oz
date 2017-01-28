using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour {

    public GameObject trumpet;
    public GameObject tooth;

    public int num_trumpet = 20;
    public float r_trumpet = 4.0f;
    public int num_tooth = 30;
    public float r_tooth = 3.5f;

    int now_trumpet = 0;
    int now_tooth = 0;
    
	void Start () {
        Application.targetFrameRate = 60;
	}
	
	void Update () {
        int t = Time.frameCount;
	    if (now_trumpet < num_trumpet && Time.frameCount % 6 == 0) {
            float rad = 2.0f * Mathf.PI * now_trumpet / num_trumpet;
            Vector3 pos = new Vector3(r_trumpet*Mathf.Cos(rad), -3.2f, r_trumpet*Mathf.Sin(rad));
            GameObject obj = (GameObject)Instantiate(trumpet, pos, transform.rotation);
            obj.transform.Rotate(0, 135 - rad*Mathf.Rad2Deg, 10);
            obj.transform.parent = transform;
            now_trumpet += 1;
        }
        if (now_tooth < num_tooth && Time.frameCount % 6 == 0)
        {
            float rad = 2.0f * Mathf.PI * now_tooth / num_tooth;
            Vector3 pos = new Vector3(r_tooth * Mathf.Cos(rad), -0.35f, r_tooth * Mathf.Sin(rad));
            GameObject obj = (GameObject)Instantiate(tooth, pos, transform.rotation);
            obj.transform.Rotate(0, 45 - rad * Mathf.Rad2Deg, 0);
            obj.transform.localScale = new Vector3(1.0f, 1.4f, 1.0f);
            obj.transform.parent = transform;
            now_tooth += 1;
        }
	}

    void SetSizes (string s)
    {
        Debug.Log("log");
        string[] splited = s.Split(' ');
        int w = int.Parse(splited[0]), h = int.Parse(splited[1]);
        Screen.SetResolution(w, h, false, 30);
        Instantiate(trumpet, new Vector3(Random.value*10, Random.value*10, Random.value*10), transform.rotation);
    }
}
