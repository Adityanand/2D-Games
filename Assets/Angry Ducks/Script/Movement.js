#pragma strict
var MoveSpeed:float;
var TurnSpeed:float;
var JumpSpeed:float;
function Update () 
{
transform.Translate(Vector2(1,0)*MoveSpeed*Time.deltaTime);
}