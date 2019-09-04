using UnityEngine;
using System.Collections;
public class Kill : MonoBehaviour {
	public Rigidbody2D Projectile;
	private SpriteRenderer spriterenderer;
	private SpringJoint2D Spring;
	void Start () {
		spriterenderer = GetComponent<SpriteRenderer>();
		Spring = Projectile.GetComponent<SpringJoint2D>();
	}

	void Update () {
		if(Spring==null &&Projectile.velocity.sqrMagnitude<=0.0)
		{
			Kills();
		}
	}
	void Kills(){
		/*spriterenderer.enabled=false;
		GetComponent <Rigidbody2D>().isKinematic=true;
		GetComponent <Collider2D>().enabled=false;*/
        GameObject.Destroy(gameObject);
	}
}
