using UnityEngine;
using System.Collections;

public class AnimSelect : MonoBehaviour {
	Animator anim;

	public bool Idle;
	public bool LaunchReady;
	public bool IsFlying;
	public bool Hurt;
	public float collisionImpact;

	private float CollisionImpactSqr;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Idle = true;
		LaunchReady = false;
		IsFlying = false;
		Hurt = false;
		CollisionImpactSqr = collisionImpact * collisionImpact;
		}
	void Update(){
		if (GetComponent<ProjectileDragging> ().enabled == true&&Hurt==false) {
			Idle = false;
			LaunchReady = true;
		}
		if (GetComponent<SpringJoint2D> () == null&&Hurt==false) {
			LaunchReady = false;
			IsFlying = true;
		}
	}
		void OnCollisionEnter2D(Collision2D collision){
		//if (collision.collider.tag != "Damager")
		//return;
		if (collision.relativeVelocity.sqrMagnitude < CollisionImpactSqr) {
			IsFlying = false;
			LaunchReady = false;
			Idle = false;
			Hurt = true;
		}
	}
	void FixedUpdate()
	{
		if (Idle) {
			anim.SetTrigger("Idle");
			//anim.Play("Idle");
		}
		if (LaunchReady) {
			anim.SetTrigger("LaunchReady");
			//anim.Play("LaunchReady");
		}
		if (IsFlying) { 
			anim.SetTrigger ("Flying");
			//anim.Play ("Flying");
		}
		if (Hurt) {
			anim.SetTrigger ("Hurt");
			//anim.Play("Hurt");
		}
	}
}
