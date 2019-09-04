using UnityEngine;
using System.Collections;

public class ProjectileDragging : MonoBehaviour {
	public float MaxStretch=3.0f;
	public LineRenderer iphone_slingshot_1;
	public LineRenderer iphone_slingshot_0;
	public Rigidbody2D Projectile;

	private SpringJoint2D spring;
	private Transform iphone_slingshot;
	private bool clickOn;
	private Ray rayToMouse;
	private Ray leftiphone_slingshotToProjectile;
	private float MAxStretchSqr;
	private float circleRadius;
	private Vector2 perVelocity;
	void Awake (){
		spring = GetComponent <SpringJoint2D> ();
		iphone_slingshot = spring.connectedBody.transform;
			}


	void Start () {
	 LineRendererSetup();
		rayToMouse = new Ray (iphone_slingshot.position, Vector3.zero);
		leftiphone_slingshotToProjectile = new Ray (iphone_slingshot_1.transform.position, Vector3.zero);
		MAxStretchSqr = MaxStretch * MaxStretch;
		CircleCollider2D circle = GetComponent<Collider2D> ()as CircleCollider2D;
		circleRadius = circle.radius;
	}
	

	void Update () {
	if (clickOn) {
			Dragging ();
		}
	if (spring!= null) {
			if (!GetComponent<Rigidbody2D>().isKinematic && perVelocity.sqrMagnitude >GetComponent<Rigidbody2D>().velocity.sqrMagnitude) {
				Destroy (spring);
				GetComponent<Rigidbody2D>().velocity = perVelocity;
			}
			if (!clickOn)
				perVelocity = GetComponent<Rigidbody2D>().velocity;
				LineRendererUpdate ();
		}
	
	else {
			iphone_slingshot_1.enabled=false;
			iphone_slingshot_0.enabled=false;
		}
		if (spring == null&&Projectile!=null) {
			//Projectile.GetComponent<SpringJoint2D>().enabled=true;
			Projectile.GetComponent<ProjectileDragging>().enabled=true;
			//iphone_slingshot=Projectile.GetComponent<SpringJoint2D>().connectedBody.transform;
			iphone_slingshot_0.enabled=true;
			iphone_slingshot_1.enabled=true;
		}
	}
	void LineRendererSetup (){
		iphone_slingshot_1.SetPosition (0, iphone_slingshot_1.transform.position);
		iphone_slingshot_0.SetPosition (0, iphone_slingshot_0.transform.position);

		iphone_slingshot_1.sortingLayerName = "Foreground";
		iphone_slingshot_0.sortingLayerName = "Foreground";

		iphone_slingshot_1.sortingOrder = 2;
		iphone_slingshot_0.sortingOrder = 4;
	}
	void OnMouseUp()
	{
		spring.enabled = true;
		GetComponent<Rigidbody2D>().isKinematic = false;
		clickOn = false;
	}
	void OnMouseDown()
	{
		spring.enabled = false;
		clickOn = true;
	}
	void Dragging (){
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 iphone_slingshotToMouse = mouseWorldPoint - iphone_slingshot.position;

		if (iphone_slingshotToMouse.sqrMagnitude > MAxStretchSqr) {
			rayToMouse.direction = iphone_slingshotToMouse;
			mouseWorldPoint = rayToMouse.GetPoint (MaxStretch);
		}

		mouseWorldPoint.z = 0.0f;
		transform.position = mouseWorldPoint;
		}
	void LineRendererUpdate (){
	    Vector2 iphone_slingshotToProjectile=transform.position-iphone_slingshot_1.transform.position;
	    leftiphone_slingshotToProjectile.direction=iphone_slingshotToProjectile;
		Vector3 holdPoint = leftiphone_slingshotToProjectile.GetPoint (iphone_slingshotToProjectile.magnitude + circleRadius);
		iphone_slingshot_0.SetPosition (1, holdPoint);
		iphone_slingshot_1.SetPosition (1, holdPoint);
     }
}