#pragma strict
var Speed:float;
var Bullet:Transform;
var BulletSpeed:float;
var SwampBullet:Transform;
function Update () 
{
if(Input.GetButton("Up"))
{
transform.Translate(-Vector2(1,0)*Speed*Time.deltaTime);
}
if(Input.GetButton("Down"))
{
transform.Translate(Vector2(1,0)*Speed*Time.deltaTime);
}
if(Input.GetButtonDown("Fire1"))
{
    var Shoot=Instantiate(Bullet,SwampBullet.transform.position,Quaternion.identity);
    Shoot.GetComponent.<Rigidbody2D>().velocity=transform.up.normalized * BulletSpeed;
}
}