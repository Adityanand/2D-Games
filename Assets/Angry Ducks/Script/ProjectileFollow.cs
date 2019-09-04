using UnityEngine;
using System.Collections;

public class ProjectileFollow : MonoBehaviour {
	public Transform Projectile;
	public Transform FarLeft;
	public Transform FarRight;
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x = Projectile.position.x;
		newPosition.y = Projectile.position.y;
		newPosition.x = Mathf.Clamp (newPosition.x, FarLeft.position.x, FarRight.position.x);
		newPosition.y = Mathf.Clamp (newPosition.y, FarLeft.position.x, FarRight.position.x);
		transform.position = newPosition;
	}
}
