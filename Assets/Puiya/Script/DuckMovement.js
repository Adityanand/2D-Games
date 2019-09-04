#pragma strict
var MovementSpeed:float;
var forward=false;
function Start () {

}

function Update () {
if(forward==false)
{
transform.Translate(Vector2(0,1)*MovementSpeed*Time.deltaTime);
}
if (forward==true)
{
transform.Translate(-Vector2(1,0)*MovementSpeed*Time.deltaTime);
}
}
function OnCollisionEnter2D()
{
forward=true;
}