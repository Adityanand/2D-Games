using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	public int Hitpoint=2;
	public Sprite DamageSprite;
	public float DamageImpactSpeed;

	private int currentHitPoint;
	private float DamageImpactSpeedSqr;
	private SpriteRenderer spriteRenderer;
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		currentHitPoint = Hitpoint;
		DamageImpactSpeedSqr = DamageImpactSpeed * DamageImpactSpeed;
	
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if(collision.collider.tag!="Damager")
		   return;
		if (collision.relativeVelocity.sqrMagnitude < DamageImpactSpeedSqr)
			return;
		spriteRenderer.sprite = DamageSprite;
		currentHitPoint--;
		if (currentHitPoint <= 0)
			kill();
		}
	void kill(){
		/*spriteRenderer.enabled = false;
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Rigidbody2D>().isKinematic = true;*/
        GameObject.Destroy(gameObject);
	}
	}
