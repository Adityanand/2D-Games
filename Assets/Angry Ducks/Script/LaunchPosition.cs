using UnityEngine;
using System.Collections;

public class LaunchPosition : MonoBehaviour {
	public Vector2 LaunchPositions;
	public Rigidbody2D Projectile;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Projectile.GetComponent<SpringJoint2D>()==null&&GetComponent<SpringJoint2D>().enabled==false)
		LaunchReady ();
		}
	void LaunchReady (){
			Vector3 newPosition = transform.position;
			newPosition = LaunchPositions;
			transform.position = newPosition;
		GetComponent<LaunchPosition> ().enabled = false;
		}
	}

