using UnityEngine;
using System.Collections;

public class Trumpet : MonoBehaviour {

    public Animator anim;

    public int frame_rest;

	void Start () {
        anim = GetComponent<Animator>();
        frame_rest = (int)(10 * 30 * Random.value);
    }
	
    void Refresh ()
    {
        frame_rest = (int)(40 * 30 * (Random.value * 0.5f + 0.5f));
    }

	void Update () {
        if (frame_rest <= 0)
        {
            anim.SetTrigger("Move");
            Refresh();
        }
        frame_rest -= 1;
	}
}
