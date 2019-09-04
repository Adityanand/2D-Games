using UnityEngine;
using System.Collections;

public class DuckAnim : MonoBehaviour {
    public bool forward;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        forward = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (forward == false)
        {
            anim.Play("Flying");
        }
        else
        {
            anim.Play("Movement");
        }
	}
    void OnCollisionEnter2D()
    {
        forward = true;
    }
}
